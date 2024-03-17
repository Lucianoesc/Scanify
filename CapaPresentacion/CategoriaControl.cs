using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class CategoriaControl : UserControl
    {
        public event EventHandler ClicEnFotoCategoria;

        // Delegado para definir el tipo de evento
        public delegate void ActualizadorEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ActualizadorEventHandler Actualizador;

        // Método para invocar el evento
        protected virtual void OnProductosActualizados(EventArgs e)
        {
            Actualizador?.Invoke(this, e);
        }
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



        public CategoriaControl()
        {
            InitializeComponent();

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                int idCategoria = Convert.ToInt32(lblId.Text);

                using (Md_Categoria frm = new Md_Categoria(idCategoria))
                {
                    // Obtener los datos del producto desde los controles de este CartaControl
                    string titulo = Titulo;
                    string estado = Estado;

                    // Cargar los datos del producto en el formulario ModalControladorProductos
                    frm.CargarDatosProducto(idCategoria, titulo, estado);

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
                OnProductosActualizados(EventArgs.Empty);
                background.Dispose();
            }
        }



        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realmente eliminar la categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                Categoria objcategoria = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(lblId.Text)
                };
                bool respuesta = new CN_Categoria().Eliminar(objcategoria, out mensaje);
                if (respuesta)
                {
                    // Invocar el evento para notificar que los productos han sido actualizados
                    OnProductosActualizados(EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }




        public Image ByteAimagen(byte[] imagenBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes, 0, imagenBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        }
        protected virtual void OnClicEnFotoCategoria(EventArgs e)
        {

            ClicEnFotoCategoria?.Invoke(this, e);
        }
        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                OnClicEnFotoCategoria(EventArgs.Empty );
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }



        private void picFoto_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                contextMenuStrip1.Show(pictureBox1, e.Location);
            }
        }
    }
}
