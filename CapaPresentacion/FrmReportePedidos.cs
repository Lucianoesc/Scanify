using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
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
    public partial class FrmReportePedidos : Form
    {
        public FrmReportePedidos()
        {
            InitializeComponent();
        }

        private void FrmReportePedidos_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cmbBusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbBusqueda.DisplayMember = "Texto";
            cmbBusqueda.ValueMember = "Value";
            cmbBusqueda.SelectedIndex = 0;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verificar si se hizo clic en el botón "btnSeleccionar"
                if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
                {
                    int indice = e.RowIndex;

                    if (indice >= 0)
                    {
                        txtIndice.Text = indice.ToString();
                        txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();

                        txtFecha.Text = dgvData.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                        txtHora.Text = dgvData.Rows[indice].Cells["HoraPedido"].Value.ToString();
                        txtCodigoPedido.Text = dgvData.Rows[indice].Cells["NumeroDocumento"].Value.ToString();
                        txtIdPedido.Text = dgvData.Rows[indice].Cells["IdPedido"].Value.ToString();

                        txtEstado.Text = dgvData.Rows[indice].Cells["Estado"].Value.ToString();
                        cmbEstado.Text = dgvData.Rows[indice].Cells["Estado"].Value.ToString();

                        panelvista.Visible = false;
                        panelCambiarEstado.Visible = true;
                        //txtFechaInicio.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaInicio"].Value);
                        //txtFechaFin.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaFin"].Value);

                        //int idOferta = Convert.ToInt32(dgvData.Rows[indice].Cells["Id"].Value);


                    }

                }
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.editar.Width;
                var h = Properties.Resources.editar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Width - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.editar, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idPedido = Convert.ToInt32(txtIdPedido.Text);
            string nuevoEstado = cmbEstado.Text;

            bool resultado = new CN_Pedido().ModificarEstadoPedido(idPedido, nuevoEstado);

            if (resultado)
            {
                MessageBox.Show("Estado del pedido fue actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                panelCambiarEstado.Visible = false;
                panelvista.Visible = true;
                btnbuscarproductos.PerformClick();

            }
            else
            {
                MessageBox.Show("No se pudo actualizar el estado del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelCambiarEstado.Visible = false;

            panelvista.Visible = true;
            limpiar();
        }

        private void btnbuscarproductos_Click(object sender, EventArgs e)
        {
            List<Pedido> listaPedidos = new CN_Pedido().ObtenerReportePedido(
             dtpFechaInicio.Value.ToString("yyyy-MM-dd"),
             dtpFechaFin.Value.ToString("yyyy-MM-dd")
             );

            dgvData.Rows.Clear();

            foreach (Pedido pedido in listaPedidos)
            {
                dgvData.Rows.Add(new object[]
                {"",pedido.IdPedido,
            pedido.FechaRegistro,
            pedido.HoraPedido,
            pedido.NumeroDocumento,
            pedido.IdPedido,
            pedido.Estado
                });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBusqueda.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtIdPedido.Text = "0";
            txtFecha.Text = "";
            txtHora.Text = "";
            txtCodigoPedido.Text = "";
            txtEstado.Text = "";
            txtBuscar.Text = "";
            cmbEstado.SelectedIndex = 0;
        }
        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
