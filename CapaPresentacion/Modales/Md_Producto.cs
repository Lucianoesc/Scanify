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
    public partial class Md_Producto : MaterialForm
    {
        public Producto _Producto { get; set; }
        public Md_Producto()
        {
            InitializeComponent();
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

        private void Md_Producto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Visible == true)
                {
                    cmbBusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbBusqueda.DisplayMember = "Texto";
            cmbBusqueda.ValueMember = "Value";
            cmbBusqueda.SelectedIndex = 0;

            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                dgvData.Rows.Add(new object[] {item.IdProducto,item.Nombre,item.Descripcion
                });

            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum > 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvData.Rows[iRow].Cells["Id"].Value.ToString()),
                    Nombre = dgvData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Descripcion = dgvData.Rows[iRow].Cells["Descripcion"].Value.ToString(),


                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
