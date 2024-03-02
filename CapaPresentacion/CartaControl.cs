using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf.codec.wmf;
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
    public partial class CartaControl : UserControl
    {
        // Delegado para definir el tipo de evento
        public delegate void ProductosActualizadosEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ProductosActualizadosEventHandler ProductosActualizados;

        // Método para invocar el evento
        protected virtual void OnProductosActualizados(EventArgs e)
        {
            ProductosActualizados?.Invoke(this, e);
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
        
        


        public CartaControl()
        {
            InitializeComponent();
            picFoto.MouseClick += pictureBox1_MouseClick;

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                int idProducto = Convert.ToInt32(lblId.Text);
                int idCategoria = Convert.ToInt32(lblCategoria.Text);
                int idSubCategoria = Convert.ToInt32(lblSubCategoria.Text);
                int idSubCategoria2 = Convert.ToInt32(lblSubCategoria2.Text);
                using (ModalControladorProductos frm = new ModalControladorProductos(idCategoria, idSubCategoria, idSubCategoria2, idProducto))
                {
                    // Obtener los datos del producto desde los controles de este CartaControl
                    string titulo = Titulo;
                    string descripcion = Descripcion;
                    string codigo = Codigo;
                    int categoria = Convert.ToInt32(Categoria);
                    int subcategoria = Convert.ToInt32(SubCategoria);
                    int subcategoria2 = Convert.ToInt32(SubCategoria2);

                    string stock = Stock;
                    string precioCompra = PrecioCompra;
                    string precioVenta = PrecioVenta;
                    string estado = Estado;
                    string infonutricional = InfoNutricional;
                    string stockminimo = StockMinimo;
                    string stocklimite = StockLimite;

                    // Cargar los datos del producto en el formulario ModalControladorProductos
                    frm.CargarDatosProducto(idProducto, titulo, descripcion, codigo, categoria, subcategoria, subcategoria2,
                        stock, precioCompra, precioVenta, estado, infonutricional, stockminimo, stocklimite);

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
        public Image ByteAimagen(byte[] imagenBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes, 0, imagenBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        }
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

       
        
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realmente eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;
                Producto objproducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(lblId.Text)
                };
                bool respuesta = new CN_Producto().Eliminar(objproducto, out mensaje);
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

        private void picFoto_Click(object sender, EventArgs e)
        {
            
        }

        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                contextMenuStrip1.Show(picFoto, e.Location);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                contextMenuStrip1.Show(pictureBox1, e.Location);
            }
        }
    }
}
