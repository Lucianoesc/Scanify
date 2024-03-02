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
    public partial class SubCategoria2Clientes : UserControl
    {
        public event EventHandler SubCategoria2Seleccionada;
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
        public SubCategoria2Clientes()
        {
            InitializeComponent();
        }
        protected virtual void OnClicEnFotoSubCategoria(EventArgs e)
        {
            SubCategoria2Seleccionada?.Invoke(this, e);
        }

        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                OnClicEnFotoSubCategoria(EventArgs.Empty);
            }
        }
    }
}
