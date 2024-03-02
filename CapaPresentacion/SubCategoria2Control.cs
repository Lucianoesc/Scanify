using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using iTextSharp.text.pdf.codec.wmf;
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
    public partial class SubCategoria2Control : UserControl
    {
        public delegate void ActualizadorEventHandler(object sender, EventArgs e);
        public event EventHandler SubCategoria2Seleccionada;

        // Evento que se disparará cuando se actualicen los productos
        public event ActualizadorEventHandler SubCategoria2Actualizada;
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
        public string IdSubCategoria
        {
            get { return lblIdSubCategoria.Text; }
            set { lblIdSubCategoria.Text = value; }
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
        public SubCategoria2Control()
        {
            InitializeComponent();
        }
        
        private void SubCategoria2Control_Load(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realmente eliminar la subcategoria2?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                SubCategoria2 objsubcategoria2 = new SubCategoria2()
                {
                    IdSubCategoria2 = Convert.ToInt32(lblId.Text)
                };
                bool respuesta = new CN_SubCategoria2().Eliminar(objsubcategoria2, out mensaje);
                if (respuesta)
                {
                    SubCategoria2Actualizada?.Invoke(this, e);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                int idSubCategoria2 = Convert.ToInt32(lblId.Text);
                int idSubCategoria = Convert.ToInt32(lblIdSubCategoria.Text);

                using (Md_SubCategoria2 frm = new Md_SubCategoria2(idSubCategoria, idSubCategoria2))
                {
                    string titulo = Titulo;
                    string estado = Estado;

                    // Cargar los datos del producto en el formulario ModalControladorProductos
                    frm.CargarDatosProducto(idSubCategoria2, titulo, estado);

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
                SubCategoria2Actualizada?.Invoke(this, e);
                background.Dispose();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                contextMenuStrip1.Show(pictureBox1, e.Location);
            }
        }

        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SubCategoria2Seleccionada?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
