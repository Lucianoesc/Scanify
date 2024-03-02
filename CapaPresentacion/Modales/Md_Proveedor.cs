using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using MaterialSkin.Controls;
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
    public partial class Md_Proveedor : MaterialForm
    {
        public Proveedor _Proveedor { get; set; }
        public Md_Proveedor()
        {
            InitializeComponent();
        }

        private void Md_Proveedor_Load(object sender, EventArgs e)
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

            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                dgvData.Rows.Add(new object[] {item.IdProveedor,item.RazonSocial,item.Telefono
                });

            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if(iRow >= 0 && iColum > 0)
            {
                _Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvData.Rows[iRow].Cells["Id"].Value.ToString()),
                    RazonSocial = dgvData.Rows[iRow].Cells["RazonSocial"].Value.ToString(),
                    Telefono = dgvData.Rows[iRow].Cells["Telefono"].Value.ToString()

                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
