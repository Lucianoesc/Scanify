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
    public partial class FrmOfertas_Productos : Form
    {
        private CN_Oferta _OfertaNegocio;


        public FrmOfertas_Productos()
        {
            _OfertaNegocio = new CN_Oferta();

            InitializeComponent();
        }

        private void FrmOfertas_Productos_Load(object sender, EventArgs e)
        {
            dgvData.ReadOnly = false;
            dgvData.Columns["chkBox"].ReadOnly = false;

            // Cargar las ofertas solo si hay al menos una
            List<Oferta> listaOfertas = new CN_Oferta().Listar();
            if (listaOfertas.Count > 0)
            {
                foreach (Oferta item in listaOfertas)
                {
                    cmbOfertas.Items.Add(new OpcionCombo() { Valor = item.IdOferta, Texto = item.NombreOferta });
                }
                cmbOfertas.DisplayMember = "Texto";
                cmbOfertas.ValueMember = "Value";
                cmbOfertas.SelectedIndex = 0;
            }
            else
            {
                // Si no hay ofertas, muestra un mensaje informativo y deshabilita los controles relacionados
                MessageBox.Show("No hay ofertas disponibles en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false; // Deshabilitar el botón para asociar productos
                btnDesasociar.Enabled = false; // Deshabilitar el botón para desasociar productos
            }

            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar" && column.Name != "chkBox")
                {
                    cmbBusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbBusqueda.DisplayMember = "Texto";
            cmbBusqueda.ValueMember = "Value";
            cmbBusqueda.SelectedIndex = 0;

            List<Producto> lista = new CN_Oferta().ListarProductos_Oferta();

            foreach (Producto item in lista)
            {
                dgvData.Rows.Add(new object[] { false, item.IdProducto, item.Nombre, item.Codigo, item.oCategoria.IdCategoria, item.oCategoria.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idOferta = 0;
            if (cmbOfertas.SelectedItem != null)
            {
                // Obtiene el valor (ID de la oferta) del ComboBox
                OpcionCombo opcionCombo = (OpcionCombo)cmbOfertas.SelectedItem;
                idOferta = (int)opcionCombo.Valor;
                // Resto del código para asociar productos a la oferta utilizando el ID de la oferta seleccionada
                // ...
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una oferta antes de asociar productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Supongamos que tienes una variable para almacenar el ID de la oferta seleccionada

            // Supongamos que tienes un DataGridView llamado dtgvProductos
            // y una columna de CheckBox llamada "chkSeleccion"

            // Crear una lista para almacenar los IDs de los productos seleccionados
            List<int> productosSeleccionados = new List<int>();

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                DataGridViewCheckBoxCell chk = fila.Cells["chkBox"] as DataGridViewCheckBoxCell;

                // Comprobar si el CheckBox está marcado
                if (Convert.ToBoolean(chk.Value))
                {
                    // Obtener el ID del producto de la fila actual
                    int idProducto = Convert.ToInt32(fila.Cells["Id"].Value);
                    productosSeleccionados.Add(idProducto);
                    chk.Value = false;

                }
            }
            if (productosSeleccionados.Count > 0)
            {
                string mensaje = "";
                bool exito = _OfertaNegocio.AsociarProductosAOferta(idOferta, productosSeleccionados, out mensaje);

                if (exito)
                {
                    MessageBox.Show("Producto/s asociados con éxito.");
                }
                else
                {
                    MessageBox.Show("Error al asociar productos: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos un producto.");

            }

        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            
        }
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvData.Columns["chkBox"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = dgvData.Rows[e.RowIndex].Cells["chkBox"] as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    cell.Value = !(bool)cell.Value; // Cambia el valor del checkbox
                    dgvData.EndEdit(); // Finaliza la edición de la celda
                }
            }
        }

        private void btnDesasociar_Click(object sender, EventArgs e)
        {
            int idOferta = 0;
            if (cmbOfertas.SelectedItem != null)
            {
                OpcionCombo opcionCombo = (OpcionCombo)cmbOfertas.SelectedItem;
                idOferta = (int)opcionCombo.Valor;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una oferta antes de desasociar productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            List<int> productosSeleccionados = new List<int>();

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                DataGridViewCheckBoxCell chk = fila.Cells["chkBox"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(chk.Value))
                {
                    int idProducto = Convert.ToInt32(fila.Cells["Id"].Value);
                    productosSeleccionados.Add(idProducto);
                    chk.Value = false;

                }
            }
            if (productosSeleccionados.Count > 0)
            {
                string mensaje = "";
                bool exito = _OfertaNegocio.DesasociarProductosDeOferta(idOferta, productosSeleccionados, out mensaje);

                if (exito)
                {
                    MessageBox.Show("Producto/s desasociados con éxito.");
                }
                else
                {
                    MessageBox.Show("Error al desasociar productos: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione al menos un producto.");

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
    }
}

