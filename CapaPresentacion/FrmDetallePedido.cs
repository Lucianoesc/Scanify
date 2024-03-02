using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmDetallePedido : Form
    {
        public FrmDetallePedido()
        {
            InitializeComponent();
        }

        private void FrmDetallePedido_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Pedido oPedido = new CN_Pedido().ObtenerPedido(txtBuscar.Text);

            if (oPedido.IdPedido != 0)
            {
                txtnumerodocumento.Text = oPedido.NumeroDocumento;

                // Convertimos la cadena en DateTime
                DateTime fechaRegistro = DateTime.ParseExact(oPedido.FechaRegistro, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                txtFecha.Text = fechaRegistro.ToString("dd/MM/yyyy");
                txtHora.Text = fechaRegistro.ToString("HH:mm");
                txtUsuario.Text = oPedido.oUsuario.Nombre + " " + oPedido.oUsuario.Apellido;

                dtgvData.Rows.Clear();
                foreach (DetallePedido dc in oPedido.oDetallePedido)
                {
                    dtgvData.Rows.Add(new object[] { dc.oProducto.Nombre, dc.Cantidad });
                }


            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
            txtUsuario.Text = "";
            dtgvData.Rows.Clear();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (txtnumerodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string Texto_Html = Properties.Resources.SPedidos.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();


            Texto_Html = Texto_Html.Replace("@docproveedor", txtnumerodocumento.Text.ToString());
            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);
            Texto_Html = Texto_Html.Replace("@cuitnegocio", odatos.CUIT);

            Texto_Html = Texto_Html.Replace("@fecharegistro", txtFecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dtgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);


            SaveFileDialog doc = new SaveFileDialog();
            doc.FileName = string.Format("Pedido_{0}.pdf", txtnumerodocumento.Text);
            doc.Filter = "Pdf Files|*.pdf";

            if (doc.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(doc.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter escritor = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteimagen = new CN_Negocio().ObtenerFoto(out obtenido);

                    if (obtenido)
                    {
                        // Inserta la imagen como fondo
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimagen);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    // Agrega el HTML con la imagen de fondo
                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(escritor, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
 }
