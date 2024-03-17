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
    public partial class FrmEmpleados : Form
    {
        private string realPassword = ""; // Variable de clase para almacenar la contraseña real

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panelVistaEmpleados.Visible = true;
            panelGestionUsuarios.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelGestionUsuarios.Visible = true;
            panelVistaEmpleados.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            label1.Visible = false;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cmbRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });

            }
            cmbRol.DisplayMember = "Texto";
            cmbRol.ValueMember = "Value";
            cmbRol.SelectedIndex = 0;

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

            //Mostrar todos los usuarios
            List<Usuario> ListaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in ListaUsuario)
            {
                dgvData.Rows.Add(new object[] {"",item.IdUsuario,item.Username,item.Clave,item.Nombre,item.Apellido,item.Documento,item.Telefono,item.Correo,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo",
                });

            }
        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtUsername.Text = "";
            cmbRol.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
            realPassword = "";
            txtNombre.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtDocumento.Text) ||
                string.IsNullOrEmpty(txtClave.Text) ||
                cmbRol.SelectedIndex == -1 ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Hay campos obligatorios vacios. Por favor, complete los campos requeridos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = realPassword;
            string mensaje = string.Empty;
            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Username = txtUsername.Text,
                Clave = txtClave.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = txtDocumento.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cmbRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1 ? true : false,
            };

            if (objusuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objusuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    // Llamada para actualizar el dígito verificador después del registro
                    ActualizarDigitoVerificador(idusuariogenerado);

                    dgvData.Rows.Add(new object[] { "", idusuariogenerado, txtUsername.Text, txtClave.Text,txtNombre.Text, txtApellido.Text, txtDocumento.Text, txtTelefono.Text, txtCorreo.Text, ((OpcionCombo)cmbRol.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbRol.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString() });

                    limpiar();
                    panel7.Visible = false;
                    panelVistaEmpleados.Visible = true;
                    panelGestionUsuarios.Visible = false;
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);
                if (resultado)
                {
                    // Llamada para actualizar el dígito verificador después de la edición
                    ActualizarDigitoVerificador(objusuario.IdUsuario);

                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Username"].Value = txtUsername.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Apellido"].Value = txtApellido.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Clave"].Value = password;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cmbRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cmbRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString();

                    limpiar();
                    panel7.Visible = false;
                    panelVistaEmpleados.Visible = true;
                    panelGestionUsuarios.Visible = false;
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }
        private void ActualizarDigitoVerificador(int idUsuario)
        {
            // Llamar al método para actualizar el dígito verificador
            char digitoVerificador;
            string mensajeActualizacion;
            bool exitoActualizacion = new CN_Usuario().ActualizarDigitoVerificador(idUsuario, out digitoVerificador, out mensajeActualizacion);

            // Verificar si la actualización fue exitosa
            if (exitoActualizacion)
            {
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Hubo un error al actualizar el dígito verificador: " + mensajeActualizacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            limpiar();

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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel7.Visible = true;
            txtClave.Text = "*****";
            panelGestionUsuarios.Visible = true;
            panelVistaEmpleados.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            label1.Visible = false;
            panel9.Visible = true;


            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtUsername.Text = dgvData.Rows[indice].Cells["Username"].Value.ToString();

                    // Almacena la contraseña real en la variable realPassword
                    realPassword = dgvData.Rows[indice].Cells["Clave"].Value.ToString();

                    // Llena el txtClave.Text con asteriscos

                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtApellido.Text = dgvData.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtDocumento.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();

                    // Autocompletamos el respectivo Rol del usuario
                    foreach (OpcionCombo oc in cmbRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cmbRol.Items.IndexOf(oc);
                            cmbRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    // También el Estado
                    foreach (OpcionCombo oc in cmbEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cmbEstado.Items.IndexOf(oc);
                            cmbEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea realmente eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {

                        IdUsuario = Convert.ToInt32(txtId.Text)

                    };
                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);
                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));

                        limpiar();
                        panel7.Visible = false;
                        panelVistaEmpleados.Visible = true;
                        panelGestionUsuarios.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
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

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
