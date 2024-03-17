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
    public partial class CategoriasClientes : UserControl
    {
        public event EventHandler ClicEnFotoCategoria;

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
        public string SubCategoria
        {
            get { return lblSubCategoria.Text; }
            set { lblSubCategoria.Text = value; }
        }
        public string SubCategoria2
        {
            get { return lblSubCategoria2.Text; }
            set { lblSubCategoria2.Text = value; }
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
        public CategoriasClientes()
        {
            InitializeComponent();
        }

        private void CategoriasClientes_Load(object sender, EventArgs e)
        {

        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }
        protected virtual void OnClicEnFotoCategoria(EventArgs e)
        {

            ClicEnFotoCategoria?.Invoke(this, e);
        }
        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                OnClicEnFotoCategoria(EventArgs.Empty);
            }
        }
    }
}
