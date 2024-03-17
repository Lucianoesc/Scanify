using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
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
    public partial class SubCategoriaControl : UserControl
    {
        public event EventHandler ClicEnFotoSubCategoria;

        public delegate void ActualizadorEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ActualizadorEventHandler SubCategoriaActualizada;

        // Método para invocar el evento
       
        public string Id
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
        }
        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
        public string IdCategoria
        {
            get { return lblIdCategoria.Text; }
            set { lblIdCategoria.Text = value; }
        }
        public string Estado
        {
            get { return lblEstado.Text; }
            set { lblEstado.Text = value; }
        }
        public Image Foto
        {
            get { return picFoto.Image; }
            set { picFoto.Image = value; }
        }
        public SubCategoriaControl()
        {
            InitializeComponent();
        }

        private void SubCategoriaControl_Load(object sender, EventArgs e)
        {

        }
        protected virtual void OnClicEnFotoSubCategoria(EventArgs e)
        {

            ClicEnFotoSubCategoria?.Invoke(this, e);
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                int idSubCategoria = Convert.ToInt32(lblId.Text);
                int idCategoria = Convert.ToInt32(lblIdCategoria.Text);

                using (Md_SubCategoria frm = new Md_SubCategoria(idCategoria, idSubCategoria))
                {
                    string titulo = Titulo;
                    string estado = Estado;

                    // Cargar los datos del producto en el formulario ModalControladorProductos
                    frm.CargarDatosProducto(idSubCategoria, titulo, estado);

                    background.StartPosition = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = System.Drawing.Color.Black;
                    background.WindowState = FormWindowState.Maximized;
                    background.Location = this.Location;
                    background.ShowInTaskbar = false;
                    background.Show();

                    frm.Owner = background;
                    frm.ShowDialog();
                    background.Dispose();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                SubCategoriaActualizada?.Invoke(this, e);
                background.Dispose();
            }
        }

        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                OnClicEnFotoSubCategoria(EventArgs.Empty);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                contextMenuStrip1.Show(pictureBox1, e.Location);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realmente eliminar la subcategoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                SubCategoria objsubcategoria = new SubCategoria()
                {
                    IdSubCategoria = Convert.ToInt32(lblId.Text)
                };
                bool respuesta = new CN_SubCategoria().Eliminar(objsubcategoria, out mensaje);
                if (respuesta)
                {
                    // Invocar el evento para notificar que los productos han sido actualizados
                    SubCategoriaActualizada?.Invoke(this, e);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
