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
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtBuscar.Text);

            if (oCompra.IdCompra != 0)
            {
                txtnumerodocumento.Text = oCompra.NumeroDocumento;

                // Convertimos la cadena en DateTime
                DateTime fechaRegistro = DateTime.ParseExact(oCompra.FechaRegistro, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                txtFecha.Text = fechaRegistro.ToString("dd/MM/yyyy");
                txtHora.Text = fechaRegistro.ToString("HH:mm");
                txtUsuario.Text = oCompra.oUsuario.Nombre + " " + oCompra.oUsuario.Apellido;
                txttelefono.Text = oCompra.oProveedor.Telefono;
                txtrazonsocial.Text = oCompra.oProveedor.RazonSocial;

                dtgvData.Rows.Clear();
                foreach (DetalleCompra dc in oCompra.oDetalleCompra)
                {
                    dtgvData.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }
                txtMontoTotal.Text = oCompra.MontoTotal.ToString("0.00");


            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
            txtUsuario.Text = "";
            txtnumerodocumento.Text = "";
            txtrazonsocial.Text = "";
            txttelefono.Text = "";
            dtgvData.Rows.Clear();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (txtnumerodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string Texto_Html = Properties.Resources.SCompras.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();


            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtrazonsocial.Text);
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
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtMontoTotal.Text);


            SaveFileDialog doc = new SaveFileDialog();
            doc.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            doc.Filter = "Pdf Files|*.pdf";

            if(doc.ShowDialog() == DialogResult.OK)
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
