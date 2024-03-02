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
    public partial class ProductosClientes : UserControl
    {
        public event EventHandler<ProductoClickEventArgs> ProductoClick;

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

        public string Descripcion
        {
            get { return lblDescripcion.Text; }
            set { lblDescripcion.Text = value; }
        }
        public string Codigo
        {
            get { return lblCodigo.Text; }
            set { lblCodigo.Text = value; }
        }
        public string Categoria
        {
            get { return lblCategoria.Text; }
            set { lblCategoria.Text = value; }
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
        public string Stock
        {
            get { return lblStock.Text; }
            set { lblStock.Text = value; }
        }
        public string Precio
        {
            get { return lblprecio.Text; }
            set { lblprecio.Text = value; }
        }
        public string PrecioCompra
        {
            get { return lblPrecioCompra.Text; }
            set { lblPrecioCompra.Text = value; }
        }
        public string PrecioVenta
        {
            get { return lblPrecioVenta.Text; }
            set { lblPrecioVenta.Text = value; }
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
        public string StockMinimo
        {
            get { return lblStockMinimo.Text; }
            set { lblStockMinimo.Text = value; }
        }
        public string StockLimite
        {
            get { return txtStockLimite.Text; }
            set { txtStockLimite.Text = value; }
        }
        public string InfoNutricional
        {
            get { return lblInfoNutricional.Text; }
            set { lblInfoNutricional.Text = value; }
        }
        public ProductosClientes()
        {
            InitializeComponent();
        }

        private void ProductosClientes_Load(object sender, EventArgs e)
        {


        }
        public class ProductoClickEventArgs : EventArgs
        {
            public int IdProducto { get; }

            public ProductoClickEventArgs(int idProducto)
            {
                IdProducto = idProducto;
            }
        }
        protected virtual void OnProductoClick(EventArgs e)
        {
            ProductoClick?.Invoke(this, (ProductoClickEventArgs)e);
        }
        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int idProducto = int.Parse(lblId.Text); // Obtener el ID del producto desde el control
                OnProductoClick(new ProductoClickEventArgs(idProducto));
            }
        }

        private void picFoto_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int idProducto = int.Parse(lblId.Text); // Obtener el ID del producto desde el control
                OnProductoClick(new ProductoClickEventArgs(idProducto));
            }
        }
    }
}
