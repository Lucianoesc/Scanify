using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmRegistrarCompra : Form
    {
        private Usuario _Usuario;

        public FrmRegistrarCompra(Usuario oUsuario)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FrmRegistrarCompra_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");
            txtIdProveedor.Text = "0";
            txtIdProducto.Text = "0";
        }
        private void Limpiar()
        {
            txtIdProducto.Text = "0";
            txtNombre.Text = "";
            txtNombre.BackColor= System.Drawing.Color.White;
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidad.Value = 0;


        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new Md_Proveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtrazonsocial.Text = modal._Proveedor.RazonSocial;
                    txttelefono.Text = modal._Proveedor.Telefono;
                }
                else
                {
                    txtrazonsocial.Focus();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new Md_Producto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtNombre.Text = modal._Producto.Nombre;
                    txtDescripcion.Text = modal._Producto.Descripcion;
                    txtPrecioCompra.Focus();
                }
                else
                {
                    txtNombre.Focus();
                }
            }
        }

        private void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecioCompra.Text, out preciocompra))
            {
                MessageBox.Show("Precio compra - formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioventa))
            {
                MessageBox.Show("Precio venta - formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach (DataGridViewRow fila in dtgvData.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                dtgvData.Rows.Add(new object[]{
                    txtIdProducto.Text,
                    txtNombre.Text,
                    preciocompra.ToString("0.00"),
                    precioventa.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value*preciocompra).ToString("0.00")
                });
            }
            CalcularTotal();
            Limpiar();
            txtNombre.Select();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            CN_Bitacora cnBitacora = new CN_Bitacora();





            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dtgvData.Rows)
            {
                int idProducto;
                decimal precioCompra;
                decimal precioVenta;
                int cantidad;
                decimal montoTotal;

                if (int.TryParse(row.Cells["IdProducto"].Value?.ToString(), out idProducto) &&
                    decimal.TryParse(row.Cells["PrecioCompra"].Value?.ToString(), out precioCompra) &&
                    decimal.TryParse(row.Cells["PrecioVenta"].Value?.ToString(), out precioVenta) &&
                    int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out cantidad) &&
                    decimal.TryParse(row.Cells["SubTotal"].Value?.ToString(), out montoTotal))
                {
                    detalle_compra.Rows.Add(new object[]
                    {
                idProducto,
                precioCompra,
                precioVenta,
                cantidad,
                montoTotal
                    });
                }
                else
                {
                    // Manejar el caso en que los valores no se puedan convertir correctamente
                    MessageBox.Show("Error: No se pudo convertir uno o más valores de la fila a tipos de datos adecuados.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);

            if (respuesta)
            {
                cnBitacora.InsertarBitacora(_Usuario.Username, _Usuario.IdUsuario.ToString(), "Solicitud de compra", "Solicitud exitosa", "FrmRegistrarCompra");

                var result = MessageBox.Show("Numero de compra generada:\n" + numerodocumento + "\n\n¿Desea copiar en el portapapeles?" + "\nPuedes copiarlo en el form de Detalle de compra para visualizarla", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerodocumento);
                txtIdProveedor.Text = "0";
                txtrazonsocial.Text = "";
                txttelefono.Text = "";
                dtgvData.Rows.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CalcularTotal()
        {
            decimal total = 0;
            if (dtgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvData.Rows)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString());

            }
            txtTotalPagar.Text = total.ToString("0.00");
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Nombre == txtNombre.Text && p.Estado == true).FirstOrDefault();
                if(oProducto != null)
                {
                    txtNombre.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtDescripcion.Text = oProducto.Descripcion;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtNombre.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtDescripcion.Text = "";
                }
            }
        }

        private void dtgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.eliminaralgo.Width;
                var h = Properties.Resources.eliminaralgo.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Width - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.eliminaralgo, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvData.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dtgvData.Rows.RemoveAt(indice);
                    CalcularTotal();
                }
            }
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            panelOpciones.Visible = false;
            panelRegistrarCompra.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmInicioEmpleados
            FrmInicioEmpleados frm = Application.OpenForms.OfType<FrmInicioEmpleados>().FirstOrDefault() ?? new FrmInicioEmpleados(_Usuario);

            // Encuentra el panel llamado "DetallePedido" en el formulario FrmInicioEmpleados
            Panel panelDetalleCompra = frm.Controls.Find("DetalleCompra", true).FirstOrDefault() as Panel;

            if (panelDetalleCompra != null)
            {


                panelDetalleCompra.Visible = true;
                Button btn = frm.Controls.Find("btnDetalleCompra", true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    System.Drawing.Color colorOriginal = btn.ForeColor;
                    Image imageOriginal = btn.Image;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.Image = null;
                    btn.PerformClick();
                    panelDetalleCompra.Visible = false;
                    btn.ForeColor = colorOriginal;
                    btn.Image = imageOriginal;
                }



            }
        }
    }
}
