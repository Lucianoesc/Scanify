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
    public partial class CarritoControl : UserControl
    {

        public string Id
        {
            get { return txtId.Text; }
            set { txtId.Text = value; }
        }

        public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }
        public string PrecioCompra
        {
            get { return lblPrecio.Text; }
            set { lblPrecio.Text = value; }
        }
        public string Cantidad
        {
            get { return lblCantidad.Text; }
            set { lblCantidad.Text = value; }
        }
        public Image Foto
        {
            get { return picFoto.Image; }
            set { picFoto.Image = value; }
        }
        public string Oferta
        {
            get { return lblOferta.Text; }
            set { lblOferta.Text = value; }
        }
        public string PrecioDescuento
        {
            get { return lblPrecioOferta.Text; }
            set { lblPrecioOferta.Text = value; }
        }
        public CarritoControl()
        {
            InitializeComponent();
            Borrar.Click += Borrar_Click;

        }
        public event EventHandler OnBorrarClicked;

        private void CarritoControl_Load(object sender, EventArgs e)
        {

        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            OnBorrarClicked?.Invoke(this, EventArgs.Empty);

        }
    }
}
