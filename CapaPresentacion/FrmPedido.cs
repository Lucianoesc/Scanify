using CapaEntidad;
using CapaNegocio;
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
    public partial class FrmPedido : Form
    {
        private Usuario _Usuario;

        public FrmPedido(Usuario oUsuario = null)
        {
            InitializeComponent();
            _Usuario = oUsuario;

        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");
            txtIdProducto.Text = "0";
        }
        private void Limpiar()
        {
            txtCantidad.Value = 1;
            txtIdProducto.Text = "0";
            txtNombre.Text = "";
            txtNombre.BackColor = System.Drawing.Color.White;
            txtDescripcion.Text = "";


        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

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
                }
                else
                {
                    txtNombre.Focus();
                }
            }
        }

       

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            if (dtgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la pedido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_pedido = new DataTable();

            detalle_pedido.Columns.Add("IdProducto", typeof(int));
            detalle_pedido.Columns.Add("Cantidad", typeof(int));


            foreach (DataGridViewRow row in dtgvData.Rows)
            {
                detalle_pedido.Rows.Add(
                    new object[]
                    {
                       Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                       row.Cells["Cantidad"].Value.ToString()

            });
            }

            int idcorrelativo = new CN_Pedido().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            Pedido oPedido = new Pedido()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                NumeroDocumento = numerodocumento,
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_Pedido().Registrar(oPedido, detalle_pedido, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra generada:\n" + numerodocumento + "\n\n¿Desea copiar en el portapapeles?" + "\nPuedes copiarlo en el form de Detalle de compra para visualizarla", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerodocumento);
                dtgvData.Rows.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            bool producto_existe = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    txtDescripcion.Text,
                    txtCantidad.Value.ToString()
                });
            }
            Limpiar();
            txtNombre.Select();
        }
    }
}
