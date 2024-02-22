using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using Siticone.Desktop.UI.WinForms;
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
    public partial class FrmBusquedaCategoria : Form
    {
        
        public int IdOferta { get; set; }
        private Producto productoSeleccionado;
        private FrmVistaDetalleProducto detalleproducto;
        public FrmBusquedaCategoria()
        {
            InitializeComponent();

        }

       

        private void MostrarProductosPorIdOferta()
        {
            if (IdOferta > 0)
            {
                // Asegúrate de que el IdOferta sea válido
                List<Producto> producto = new CN_Producto().ObtenerProductosPorIdOferta(IdOferta);

                if (producto != null && producto.Count > 0)
                {

                    // Mostrar los productos de la oferta obtenidos
                    MostrarProductos(producto);
                }
                else
                {
                    // Realiza alguna acción si no se obtienen productos para el IdOferta especificado
                    MessageBox.Show("No se encontraron productos para esta oferta.");
                }
            }
            else
            {
                // Si no se proporciona un IdOferta válido, mostrar todos los productos
                MostrarTodosLosProductos();
            }
        }

       
        private Image ByteAimagen(byte[] imagenBytes)
        {
            using (MemoryStream ms = new MemoryStream(imagenBytes))
            {
                return Image.FromStream(ms);
            }
        }
        
        private void FrmBusquedaCategoria_Load(object sender, EventArgs e)
        {
            SiticoneButton btnMostrarTodos = new SiticoneButton
            {
                Text = "Todos",
                BorderRadius = 15
            };

            // Asignar un manejador de eventos al botón "Mostrar Todos"
            btnMostrarTodos.Click += (btnSender, btnEvent) =>
            {
                MostrarTodosLosProductos(); // Llamar a la función para mostrar todos los productos
            };

            // Agregar el botón al contenedor de categorías
            flowLayoutPanelCategorias.Controls.Add(btnMostrarTodos);

            // Cargar las categorías
            CargarCategorias();

            // Verificar si hay una oferta seleccionada
            if (IdOferta > 0)
            {
                MostrarProductosPorIdOferta();
            }
            else
            {
                // Obtener la lista de productos solo si no hay una oferta seleccionada
                List<Producto> lista = new CN_Producto().Listar();

                foreach (Producto producto in lista)
                {
                    // Crear controles para mostrar cada producto
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = ByteAimagen(producto.Foto),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(100, 100),
                    };

                    Label labelNombre = new Label
                    {
                        Text = producto.Nombre,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Size = new Size(100, 30),
                    };

                    Label labelPrecio = new Label
                    {
                        Text = producto.PrecioCompra.ToString("C"),
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false,
                        Size = new Size(100, 30),
                    };

                    FlowLayoutPanel productContainer = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.TopDown,
                        Size = new Size(100, 160),
                    };

                    // Agregar los controles al contenedor del producto
                    productContainer.Controls.Add(pictureBox);
                    productContainer.Controls.Add(labelNombre);
                    productContainer.Controls.Add(labelPrecio);

                    // Agregar un manejador de eventos Click al PictureBox
                    pictureBox.Click += (clickedSender, ev) =>
                    {
                        // Almacena el producto seleccionado en la variable de clase
                        productoSeleccionado = producto;

                        // Crea una instancia de FrmVistaDetalleProducto
                        if (detalleproducto == null || detalleproducto.IsDisposed)
                        {
                            detalleproducto = new FrmVistaDetalleProducto(productoSeleccionado);
                            detalleproducto.PreviousForm = this;
                            detalleproducto.Show();
                        }
                    };

                    // Agregar el contenedor del producto al FlowLayoutPanel principal
                    flowLayoutPanel1.Controls.Add(productContainer);
                }
            }
        }
        
        private void MostrarProductos(List<Producto> productos)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Producto producto in productos)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = ByteAimagen(producto.Foto),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(100, 100),
                };

                Label labelNombre = new Label
                {
                    Text = producto.Nombre,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Size = new Size(100, 30),
                };

                Label labelPrecio = new Label
                {
                    Text = producto.PrecioCompra.ToString("C"),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Size = new Size(100, 30),
                };

                FlowLayoutPanel productContainer = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    Size = new Size(100, 160),
                };

                productContainer.Controls.Add(pictureBox);
                productContainer.Controls.Add(labelNombre);
                productContainer.Controls.Add(labelPrecio);

                pictureBox.Click += (clickedSender, ev) =>
                {

                    // Almacena el producto seleccionado en la variable de clase
                    productoSeleccionado = producto;

                    // Crea una instancia de FrmVistaDetalleProducto
                    detalleproducto = new FrmVistaDetalleProducto(productoSeleccionado);
                    detalleproducto.PreviousForm = this;
                    detalleproducto.Show();
                    this.Hide();
                };

                flowLayoutPanel1.Controls.Add(productContainer);
            }

        }

        private void CargarCategorias()
        {
            List<Categoria> categorias = new CN_Categoria().Listar();
            foreach (Categoria categoria in categorias)
            {
                SiticoneButton btnCategoria = new SiticoneButton
                {
                    Text = categoria.Descripcion,
                    Tag = categoria.IdCategoria, // Tag para almacenar el ID de la categoría
                    BorderRadius = 15
                };

                //  manejador de eventos para el clic en la categoría
                btnCategoria.Click += (sender, e) =>
                {
                    int idCategoria = (int)btnCategoria.Tag; // Obtener el ID de la categoría desde el Tag
                    MostrarProductosPorCategoria(idCategoria); // Llamar a la función para mostrar productos por categoría
                };

                flowLayoutPanelCategorias.Controls.Add(btnCategoria); // Agregar el botón de categoría al contenedor
            }
        }

        private void MostrarProductosPorCategoria(int idCategoria)
        {
            // Filtrar la lista de productos por la categoría seleccionada
            List<Producto> productosFiltrados = new CN_Producto().Listar()
                .Where(producto => producto.oCategoria.IdCategoria == idCategoria)
                .ToList();

            MostrarProductos(productosFiltrados);
        }
        private void MostrarTodosLosProductos()
        {
            List<Producto> todosLosProductos = new CN_Producto().Listar();
            MostrarProductos(todosLosProductos); // Llamar a la función para mostrar los productos
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }
       
        
    }

}
