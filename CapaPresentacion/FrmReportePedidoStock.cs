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
    public partial class FrmReportePedidoStock : Form
    {
        public FrmReportePedidoStock()
        {
            InitializeComponent();
        }

        private void FrmReportePedidoStock_Load(object sender, EventArgs e)
        {
            List<Producto> lista = new CN_Producto().Listar();

            cmbProductos.Items.Add(new OpcionCombo() { Valor = 0, Texto = "TODOS" });
            foreach (Producto item in lista)
            {
                cmbProductos.Items.Add(new OpcionCombo() { Valor = item.IdProducto, Texto = item.Nombre });

            }
            cmbProductos.DisplayMember = "Texto";
            cmbProductos.ValueMember = "Valor";
            cmbProductos.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dtgvData.Columns)
            {
                cmbBusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
            }
            cmbBusqueda.DisplayMember = "Texto";
            cmbBusqueda.ValueMember = "Valor";
            cmbBusqueda.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBusqueda.SelectedItem).Valor.ToString();
            if (dtgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dtgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnbuscarproductos_Click(object sender, EventArgs e)
        {
            int idProducto = Convert.ToInt32(((OpcionCombo)cmbProductos.SelectedItem).Valor.ToString());

            List<ReportePedidoStock> lista = new CN_ReportePedidoStock().PedidoStocks(
                dtpFechaInicio.Value.ToString("yyyy-MM-dd"),
                dtpFechaFin.Value.ToString("yyyy-MM-dd"),
                idProducto
            );

            dtgvData.Rows.Clear();

            foreach (ReportePedidoStock consulta in lista)
            {
                dtgvData.Rows.Add(new object[]
                {
            consulta.FechaPedidoStock,
            consulta.HoraPedidoStock,
            consulta.NombreProducto,
            consulta.CodigoProducto
                });
            }
        }
    }
}
