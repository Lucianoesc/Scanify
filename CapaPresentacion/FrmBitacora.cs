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
    public partial class FrmBitacora : Form
    {
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {

            CargarBitacora();

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
        private void MostrarBitacora(List<Bitacora> listaBitacora)
        {
            foreach (Bitacora item in listaBitacora)
            {
                dgvData.Rows.Add(new object[]
                {
                    item.IdBitacora,
                    item.Fecha.ToString(),
                    item.Hora.ToString(),
                    item.IdUsuario,
                    item.Usuario,
                    item.Evento,
                    item.Detalle,
                    item.Origen
                });
            }
        }
        private void CargarBitacora()
        {
            CN_Bitacora cnBitacora = new CN_Bitacora();
            List<Bitacora> listaBitacora = cnBitacora.ListarBitacora();

            foreach (Bitacora item in listaBitacora)
            {
                dgvData.Rows.Add(new object[]
                {
                item.IdBitacora,
                item.Fecha.ToString(),
                item.Hora.ToString(),
                item.IdUsuario,
                item.Usuario,
                item.Evento,
                item.Detalle,
                item.Origen
                });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToUpper();
            string columnaFiltro = ((OpcionCombo)cmbBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    // Verificar si la celda de la columna seleccionada contiene el texto de búsqueda
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textoBusqueda))
                    {
                        row.Visible = true; // Mostrar la fila si coincide con el filtro de búsqueda
                    }
                    else
                    {
                        row.Visible = false; // Ocultar la fila si no coincide con el filtro de búsqueda
                    }
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            CargarBitacora();
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar los registros del día de hoy
            dgvData.Rows.Clear();

            // Obtener la fecha de hoy
            DateTime fechaHoy = DateTime.Today;

            // Filtrar la lista de bitácora para obtener solo los registros del día de hoy
            CN_Bitacora cnBitacora = new CN_Bitacora(); // Asegúrate de que cnBitacora esté inicializada
            List<Bitacora> listaBitacora = cnBitacora.ListarBitacora().Where(b => DateTime.Parse(b.Fecha).Date == fechaHoy).ToList();

            // Mostrar los registros filtrados en el DataGridView
            MostrarBitacora(listaBitacora);
        }
    }
}
