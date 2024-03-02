using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using Irony.Parsing;
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
using static CapaPresentacion.ProductosClientes;

namespace CapaPresentacion
{
    public partial class FrmBusquedaCategoria : Form
    {
        private FrmVistaDetalleProducto detalleProductoForm;
        private FrmBusquedaCategoria frmBusquedaCategoria;

        private List<Oferta> ofertas;
        private List<byte[]> fotosOfertas;
        private int ofertaActualIndex;
        private int idSubCategoriaSeleccionada;
        private int idSubCategoria2Seleccionada;
        private int idCategoriaSeleccionada;

        public int IdOferta { get; set; }
        public FrmBusquedaCategoria()
        {
            InitializeComponent();

        }


        private Image ByteAimagen(byte[] imagenBytes)
        {
            using (MemoryStream ms = new MemoryStream(imagenBytes))
            {
                return Image.FromStream(ms);
            }
        }
        private void CargarProductosEnFlowLayout()
        {
            // Limpiar el FlowLayoutPanel antes de cargar los productos
            flowpanelProductos.Controls.Clear();

            // Crear una instancia de la capa de negocio de producto
            CN_Producto negocioProducto = new CN_Producto();

            // Obtener la lista de productos utilizando el método Listar de CN_Producto
            List<Producto> lista = negocioProducto.Listar();

            // Recorrer la lista de productos
            foreach (Producto producto in lista)
            {
                // Crear una instancia del control de usuario ProductosClientes
                ProductosClientes productoControl = new ProductosClientes();

                // Establecer los datos del producto en el control
                productoControl.Id = producto.IdProducto.ToString();
                productoControl.Titulo = producto.Nombre;
                productoControl.Descripcion = producto.Descripcion;
                productoControl.Codigo = producto.Codigo;
                productoControl.Categoria = producto.oCategoria.IdCategoria.ToString();
                productoControl.SubCategoria = producto.oSubCategoria.IdSubCategoria.ToString();
                productoControl.SubCategoria2 = producto.oSubCategoria2.IdSubCategoria2.ToString();
                productoControl.Stock = producto.Stock.ToString();
                productoControl.PrecioCompra = producto.PrecioCompra.ToString();
                productoControl.PrecioVenta = producto.PrecioVenta.ToString();
                productoControl.InfoNutricional = producto.InformacionNutricional;
                productoControl.Estado = producto.Estado ? "Activo" : "Inactivo";
                productoControl.StockMinimo = producto.StockMinimo.ToString();
                productoControl.StockLimite = producto.StockLimite.ToString();
                productoControl.Foto = ByteAimagen(producto.Foto); // Asegúrate de que Foto sea un arreglo de bytes
                productoControl.ProductoClick += ProductoControl_ProductoClick;

                flowpanelProductos.Controls.Add(productoControl);
            }
        }
        private void AbrirFormularioDetalleProducto(Producto producto)
        {
            // Verificar si ya hay una instancia del formulario abierta
            if (detalleProductoForm == null || detalleProductoForm.IsDisposed)
            {
                // Si no hay una instancia abierta, crear una nueva
                detalleProductoForm = new FrmVistaDetalleProducto(producto);
                detalleProductoForm.Show();
            }
            else
            {
                // Si ya hay una instancia abierta, mostrarla y enfocarla
                detalleProductoForm.Activate();
                detalleProductoForm.Focus();
            }
        }


        private void CargarCategoriasEnFlowLayout()
        {
            // Limpiar el FlowLayoutPanel antes de cargar los productos
            flowpanelCategorias.Controls.Clear();

            // Crear una instancia de la capa de negocio de categoría
            CN_Categoria negocioCategoria = new CN_Categoria();

            // Obtener la lista de categorías utilizando el método Listar de CN_Categoria
            List<Categoria> lista = negocioCategoria.Listar();

            // Recorrer la lista de categorías
            foreach (Categoria categoria in lista)
            {
                // Crear una instancia del control de usuario CategoriasClientes
                CategoriasClientes categoriaControl = new CategoriasClientes();

                // Configurar los datos de la categoría en el control
                categoriaControl.Id = categoria.IdCategoria.ToString();
                categoriaControl.Titulo = categoria.Descripcion;
                categoriaControl.Estado = categoria.Estado ? "Activo" : "Inactivo";
                categoriaControl.Foto = ByteAimagen(categoria.FotoCategoria);

                // Suscribir el evento de clic a la categoría
                categoriaControl.ClicEnFotoCategoria += CategoriaControl_ClicEnFotoCategoria;

                // Agregar el control de categoría al FlowLayoutPanel
                flowpanelCategorias.Controls.Add(categoriaControl);
            }
        }
        public Image ByteAImagen(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }
        private void FrmBusquedaCategoria_Load(object sender, EventArgs e)
        {
            // Cerrar el formulario de búsqueda si está abierto
            if (frmBusquedaCategoria != null && !frmBusquedaCategoria.IsDisposed)
            {
                frmBusquedaCategoria.Close();
            }
            //bool obtenido = true;
            //byte[] byteimagen = new CN_Negocio().ObtenerFoto(out obtenido);

            //if (obtenido)
            //{
            //    picLegales.Image = ByteAImagen(byteimagen);
            //}
            //Negocio datos = new CN_Negocio().ObtenerDatos();

            //lblLegales.Text = datos.Nombre;
            fotosOfertas = new List<byte[]>();
            ofertaActualIndex = 0;

            ofertas = new CN_Oferta().Listar();

            foreach (Oferta oferta in ofertas)
            {
                if (oferta.PantallaPrincipal != null && oferta.Foto.Length > 0)
                {
                    fotosOfertas.Add(oferta.PantallaPrincipal);
                }
            }

            MostrarOfertaActual();

            timerCarrucel.Interval = 7000;
            timerCarrucel.Tick += timerCarrucel_Tick;
            timerCarrucel.Start();

            CargarProductosEnFlowLayout();
            CargarCategoriasEnFlowLayout();
            foreach (CategoriasClientes categoriaControl in flowpanelProductos.Controls.OfType<CategoriasClientes>())
            {
                categoriaControl.ClicEnFotoCategoria += CategoriaControl_ClicEnFotoCategoria;
            }
            foreach (SubCategoriaClientes subcategoriaControl in flowpanelProductos.Controls.OfType<SubCategoriaClientes>())
            {
                subcategoriaControl.ClicEnFotoSubCategoria += SubCategoriaControl_ClicEnFotoSubCategoria;
            }
            foreach (SubCategoria2Clientes subcategoria2Control in flowpanelProductos.Controls.OfType<SubCategoria2Clientes>())
            {
                subcategoria2Control.SubCategoria2Seleccionada += SubCategoria2Control_SubCategoria2Seleccionada;
            }
            foreach (ProductosClientes productoControl in flowpanelProductos.Controls.OfType<ProductosClientes>())
            {
                productoControl.ProductoClick += ProductoControl_ProductoClick;
            }
        }
        private void ProductoControl_ProductoClick(object sender, ProductoClickEventArgs e)
        {
            // Aquí puedes utilizar el ID del producto (e.IdProducto) como desees
            int idProducto = e.IdProducto;
            // Por ejemplo, puedes utilizar el ID para cargar el detalle del producto correspondiente
            Producto producto = ObtenerProductoPorId(idProducto);
            if (producto != null)
            {
                // Mostrar el detalle del producto
                AbrirFormularioDetalleProducto(producto);
            }
        }
        private Producto ObtenerProductoPorId(int idProducto)
        {
            CN_Producto negocioProducto = new CN_Producto();

            // Obtener la lista de productos utilizando el método Listar de CN_Producto
            List<Producto> lista = negocioProducto.Listar();


            Producto producto = lista.FirstOrDefault(p => p.IdProducto == idProducto);

            return producto;
        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
            this.Dispose();

        }
        private void CategoriaControl_ClicEnFotoCategoria(object sender, EventArgs e)
        {
            

            if (sender is CategoriasClientes categoriaSeleccionada)
            {
                // Limpiar el FlowLayoutPanel antes de cargar las subcategorías
                flowpanelProductos.Controls.Clear();

                // Obtener el ID de la categoría seleccionada
                idCategoriaSeleccionada = Convert.ToInt32(categoriaSeleccionada.Id);

                // Crear una instancia de la capa de negocio de subcategoría
                CN_SubCategoria negocioSubCategoria = new CN_SubCategoria();

                // Obtener la lista de subcategorías por el ID de la categoría seleccionada
                List<SubCategoria> listaSubcategorias = negocioSubCategoria.ListarPorIdCategoria(idCategoriaSeleccionada);

                // Recorrer la lista de subcategorías
                foreach (SubCategoria subcategoria in listaSubcategorias)
                {
                    SubCategoriaClientes subcategoriaControl = new SubCategoriaClientes();
                    subcategoriaControl.Id = subcategoria.IdSubCategoria.ToString();
                    subcategoriaControl.Titulo = subcategoria.Descripcion;
                    subcategoriaControl.IdCategoria = subcategoria.oCategoria.IdCategoria.ToString();
                    subcategoriaControl.Estado = subcategoria.Estado ? "Activo" : "Inactivo";
                    subcategoriaControl.Foto = ByteAimagen(subcategoria.FotoSubCategoria);
                    subcategoriaControl.ClicEnFotoSubCategoria += SubCategoriaControl_ClicEnFotoSubCategoria;
                    lblsiguienteproductos.Visible = true;
                    lblSubCategoria2.Visible = false;
                    lblSiguienteSubCat2.Visible = false;
                    lblSubCategoria.Visible = false;
                    lblSiguienteSubCat.Visible = false;
                    lblCategoria.Visible = true;
                    lblCategoria.Text = categoriaSeleccionada.Titulo;
                    lblCategoria.BringToFront();
                    flowpanelProductos.Controls.Add(subcategoriaControl);
                }
            }
        }

        private void SubCategoriaControl_ClicEnFotoSubCategoria(object sender, EventArgs e)
        {

            SubCategoriaClientes subcategoriaSeleccionada = (SubCategoriaClientes)sender;

            // Obtener el ID de la categoría seleccionada y almacenarlo en la variable
            idSubCategoriaSeleccionada = Convert.ToInt32(subcategoriaSeleccionada.Id);

            // Obtener el ID de la categoría seleccionada

            // Limpiar el FlowLayoutPanel antes de cargar las subcategorías
            flowpanelProductos.Controls.Clear();

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria2 negocioSubCategoria = new CN_SubCategoria2();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria2> listaSubcategorias2 = negocioSubCategoria.ListarPorIdSubCategoria(idSubCategoriaSeleccionada);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria2 subcategoria2 in listaSubcategorias2)
            {
                SubCategoria2Clientes subcategoria2Control = new SubCategoria2Clientes(); // Aquí debería ser CategoriaControl en lugar de SubCategoriaControl
                subcategoria2Control.Id = subcategoria2.IdSubCategoria2.ToString();
                subcategoria2Control.Titulo = subcategoria2.Descripcion;
                subcategoria2Control.SubCategoria = subcategoria2.oSubCategoria.IdSubCategoria.ToString();
                subcategoria2Control.Estado = subcategoria2.Estado ? "Activo" : "Inactivo";
                subcategoria2Control.Foto = ByteAimagen(subcategoria2.FotoSubCategoria2);
                subcategoria2Control.SubCategoria2Seleccionada += SubCategoria2Control_SubCategoria2Seleccionada;
                lblSubCategoria.Text = subcategoriaSeleccionada.Titulo;
                lblSubCategoria.Visible = true;
                lblSiguienteSubCat.Visible = true;
                lblSiguienteSubCat.BringToFront();
                lblSubCategoria2.BringToFront();
                lblSubCategoria.BringToFront();

                flowpanelProductos.Controls.Add(subcategoria2Control);
            }
        }
        private void SubCategoria2Control_SubCategoria2Seleccionada(object sender, EventArgs e)
        {

            if (sender is SubCategoria2Clientes subcategoria2Control)
            {
                lblSubCategoria2.Text = subcategoria2Control.Titulo;
                lblSubCategoria2.Visible = true;
                lblSiguienteSubCat2.Visible = true;
                lblSubCategoria2.BringToFront();
                lblSiguienteSubCat2.BringToFront();

                int idSubCategoria2 = Convert.ToInt32(subcategoria2Control.Id);
                CargarProductosPorSubCategoria2(idSubCategoria2);
            }
        }
        private void CargarProductosPorSubCategoria2(int idSubCategoria2)
        {

            
            flowpanelProductos.Controls.Clear();


            // Resto del método permanece igual
            // Crear una instancia de la capa de negocio de productos
            CN_Producto negocioProducto = new CN_Producto();
            idSubCategoria2Seleccionada = idSubCategoria2;
            // Obtener la lista de productos por el ID de la subcategoría 2
            List<Producto> listaProductos = negocioProducto.ListarProductosPorIdSubCategoria2(idSubCategoria2Seleccionada);

            // Recorrer la lista de productos y agregar controles correspondientes al FlowLayoutPanel
            foreach (Producto producto in listaProductos)
            {
                ProductosClientes productoControl = new ProductosClientes();
                productoControl.Id = producto.IdProducto.ToString();
                productoControl.Titulo = producto.Nombre.ToString();
                productoControl.Descripcion = producto.Descripcion;
                productoControl.Categoria = producto.oCategoria.IdCategoria.ToString();
                productoControl.SubCategoria = producto.oSubCategoria.IdSubCategoria.ToString();
                productoControl.SubCategoria2 = producto.oSubCategoria2.IdSubCategoria2.ToString();
                productoControl.Codigo = producto.Codigo;
                productoControl.Stock = producto.Stock.ToString();
                productoControl.PrecioCompra = producto.PrecioCompra.ToString();
                productoControl.PrecioVenta = producto.PrecioVenta.ToString();
                productoControl.Estado = producto.Estado.ToString();
                productoControl.Foto = ByteAimagen(producto.Foto);
                productoControl.StockMinimo = producto.StockMinimo.ToString();
                productoControl.StockLimite = producto.StockLimite.ToString();
                productoControl.InfoNutricional = producto.InformacionNutricional;
                productoControl.ProductoClick += ProductoControl_ProductoClick;
                lblSubCategoria2.BringToFront();

                flowpanelProductos.Controls.Add(productoControl);
            }
        }
        
        private void flowpanelCategorias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

            // Limpiar los controles dentro de flowpanelProductos y flowpanelCategorias
            flowpanelProductos.Controls.Clear();

            // Obtener el ID de la categoría seleccionada
            int idCategoria = idCategoriaSeleccionada;

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria negocioSubCategoria = new CN_SubCategoria();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria> listaSubcategorias = negocioSubCategoria.ListarPorIdCategoria(idCategoria);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria subcategoria in listaSubcategorias)
            {
                SubCategoriaClientes subcategoriaControl = new SubCategoriaClientes();
                subcategoriaControl.Id = subcategoria.IdSubCategoria.ToString();
                subcategoriaControl.Titulo = subcategoria.Descripcion;
                subcategoriaControl.IdCategoria = subcategoria.oCategoria.IdCategoria.ToString();
                subcategoriaControl.Estado = subcategoria.Estado ? "Activo" : "Inactivo";
                subcategoriaControl.Foto = ByteAimagen(subcategoria.FotoSubCategoria);
                subcategoriaControl.ClicEnFotoSubCategoria += SubCategoriaControl_ClicEnFotoSubCategoria;
                lblsiguienteproductos.Visible = true;
                lblSubCategoria2.Visible = false;
                lblSiguienteSubCat2.Visible = false;
                lblSubCategoria.Visible = false;
                lblSiguienteSubCat.Visible = false;
                lblCategoria.Visible = true;
                lblCategoria.BringToFront();
                flowpanelProductos.Controls.Add(subcategoriaControl);
            }

        }
        private void lblSubCategoria_Click(object sender, EventArgs e)
        {

            // Limpiar los controles dentro de flowpanelProductos y flowpanelCategorias
            flowpanelProductos.Controls.Clear();

            // Obtener el ID de la categoría seleccionada
            int idSubCategoria = idSubCategoriaSeleccionada;

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria2 negocioSubCategoria2 = new CN_SubCategoria2();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria2> listaSubcategorias2 = negocioSubCategoria2.ListarPorIdSubCategoria(idSubCategoria);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria2 subcategoria2 in listaSubcategorias2)
            {
                SubCategoria2Clientes subcategoria2Control = new SubCategoria2Clientes();
                subcategoria2Control.Id = subcategoria2.IdSubCategoria2.ToString();
                subcategoria2Control.Titulo = subcategoria2.Descripcion;
                subcategoria2Control.IdCategoria = subcategoria2.oSubCategoria.IdSubCategoria.ToString();
                subcategoria2Control.Estado = subcategoria2.Estado ? "Activo" : "Inactivo";
                subcategoria2Control.Foto = ByteAimagen(subcategoria2.FotoSubCategoria2);
                subcategoria2Control.SubCategoria2Seleccionada += SubCategoria2Control_SubCategoria2Seleccionada;
                lblSiguienteSubCat2.Visible = false;
                lblSubCategoria2.Visible = false;
                lblSiguienteSubCat.Visible = true;
                lblSubCategoria2.BringToFront();
                flowpanelProductos.Controls.Add(subcategoria2Control);
            }


        }
        private void lblSubCategoria2_Click(object sender, EventArgs e)
        {

        }

        private void lblProductos_Click(object sender, EventArgs e)
        {
            if (lblsiguienteproductos.Visible == true)
            {
                lblsiguienteproductos.Visible = false;
                lblCategoria.Visible = false;
                lblSubCategoria.Visible = false;
                lblSiguienteSubCat.Visible = false;
                lblSiguienteSubCat2.Visible = false;
                lblSubCategoria2.Visible = false;

                CargarProductosEnFlowLayout();

            }
            else
            {
                lblsiguienteproductos.Visible = true;

            }


        }

        private void picOfertas_Click(object sender, EventArgs e)
        {

        }
        private void MostrarOfertaActual()
        {
            //if (fotosOfertas.Count > 0 && ofertaActualIndex >= 0 && ofertaActualIndex < fotosOfertas.Count)
            //{
            //    Image imagenOferta = ByteAImagen(fotosOfertas[ofertaActualIndex]);
            //    picOfertas.Image = imagenOferta;
            //    picOfertas.Refresh();

            //}
            //else
            //{
            //    picOfertas.Refresh();
            //}
        }
        private void timerCarrucel_Tick(object sender, EventArgs e)
        {
            if (ofertaActualIndex < fotosOfertas.Count - 1)
            {
                ofertaActualIndex++;
                MostrarOfertaActual();
            }
            else
            {
                ofertaActualIndex = -2;
                MostrarOfertaActual();

            }
        }


        //SiticoneButton btnMostrarTodos = new SiticoneButton
        //{
        //    Text = "Todos",
        //    BorderRadius = 15
        //};

        //// Asignar un manejador de eventos al botón "Mostrar Todos"
        //btnMostrarTodos.Click += (btnSender, btnEvent) =>
        //{
        //    MostrarTodosLosProductos(); // Llamar a la función para mostrar todos los productos
        //};

        //// Agregar el botón al contenedor de categorías
        //flowLayoutPanelCategorias.Controls.Add(btnMostrarTodos);

        //// Cargar las categorías
        //CargarCategorias();

        //// Verificar si hay una oferta seleccionada
        //if (IdOferta > 0)
        //{
        //    MostrarProductosPorIdOferta();
        //}
        //else
        //{
        //    // Obtener la lista de productos solo si no hay una oferta seleccionada
        //    List<Producto> lista = new CN_Producto().Listar();

        //    foreach (Producto producto in lista)
        //    {
        //        // Crear controles para mostrar cada producto
        //        PictureBox pictureBox = new PictureBox
        //        {
        //            Image = ByteAimagen(producto.Foto),
        //            SizeMode = PictureBoxSizeMode.Zoom,
        //            Size = new Size(100, 100),
        //        };

        //        Label labelNombre = new Label
        //        {
        //            Text = producto.Nombre,
        //            TextAlign = ContentAlignment.MiddleCenter,
        //            AutoSize = false,
        //            Size = new Size(100, 30),
        //        };

        //        Label labelPrecio = new Label
        //        {
        //            Text = producto.PrecioCompra.ToString("C"),
        //            TextAlign = ContentAlignment.MiddleCenter,
        //            AutoSize = false,
        //            Size = new Size(100, 30),
        //        };

        //        FlowLayoutPanel productContainer = new FlowLayoutPanel
        //        {
        //            FlowDirection = FlowDirection.TopDown,
        //            Size = new Size(100, 160),
        //        };

        //        // Agregar los controles al contenedor del producto
        //        productContainer.Controls.Add(pictureBox);
        //        productContainer.Controls.Add(labelNombre);
        //        productContainer.Controls.Add(labelPrecio);

        //        // Agregar un manejador de eventos Click al PictureBox
        //        pictureBox.Click += (clickedSender, ev) =>
        //        {
        //            // Almacena el producto seleccionado en la variable de clase
        //            productoSeleccionado = producto;

        //            // Crea una instancia de FrmVistaDetalleProducto
        //            if (detalleproducto == null || detalleproducto.IsDisposed)
        //            {
        //                detalleproducto = new FrmVistaDetalleProducto(productoSeleccionado);
        //                detalleproducto.PreviousForm = this;
        //                detalleproducto.Show();
        //            }
        //        };

        //        // Agregar el contenedor del producto al FlowLayoutPanel principal
        //        flowpanelProductos.Controls.Add(productContainer);
        //    }
        //}
    }

    //private void MostrarProductos(List<Producto> productos)
    //{
    //    flowpanelProductos.Controls.Clear();

    //    foreach (Producto producto in productos)
    //    {
    //        PictureBox pictureBox = new PictureBox
    //        {
    //            Image = ByteAimagen(producto.Foto),
    //            SizeMode = PictureBoxSizeMode.Zoom,
    //            Size = new Size(100, 100),
    //        };

    //        Label labelNombre = new Label
    //        {
    //            Text = producto.Nombre,
    //            TextAlign = ContentAlignment.MiddleCenter,
    //            AutoSize = false,
    //            Size = new Size(100, 30),
    //        };

    //        Label labelPrecio = new Label
    //        {
    //            Text = producto.PrecioCompra.ToString("C"),
    //            TextAlign = ContentAlignment.MiddleCenter,
    //            AutoSize = false,
    //            Size = new Size(100, 30),
    //        };

    //        FlowLayoutPanel productContainer = new FlowLayoutPanel
    //        {
    //            FlowDirection = FlowDirection.TopDown,
    //            Size = new Size(100, 160),
    //        };

    //        productContainer.Controls.Add(pictureBox);
    //        productContainer.Controls.Add(labelNombre);
    //        productContainer.Controls.Add(labelPrecio);

    //        pictureBox.Click += (clickedSender, ev) =>
    //        {

    //            // Almacena el producto seleccionado en la variable de clase
    //            productoSeleccionado = producto;

    //            // Crea una instancia de FrmVistaDetalleProducto
    //            detalleproducto = new FrmVistaDetalleProducto(productoSeleccionado);
    //            detalleproducto.PreviousForm = this;
    //            detalleproducto.Show();
    //            this.Hide();
    //        };

    //        flowpanelProductos.Controls.Add(productContainer);
    //    }

    //}

    //private void CargarCategorias()
    //{
    //    List<Categoria> categorias = new CN_Categoria().Listar();
    //    foreach (Categoria categoria in categorias)
    //    {
    //        SiticoneButton btnCategoria = new SiticoneButton
    //        {
    //            Text = categoria.Descripcion,
    //            Tag = categoria.IdCategoria, // Tag para almacenar el ID de la categoría
    //            BorderRadius = 15
    //        };

    //        //  manejador de eventos para el clic en la categoría
    //        btnCategoria.Click += (sender, e) =>
    //        {
    //            int idCategoria = (int)btnCategoria.Tag; // Obtener el ID de la categoría desde el Tag
    //            MostrarProductosPorCategoria(idCategoria); // Llamar a la función para mostrar productos por categoría
    //        };

    //        flowLayoutPanelCategorias.Controls.Add(btnCategoria); // Agregar el botón de categoría al contenedor
    //    }
    //}

    //private void MostrarProductosPorCategoria(int idCategoria)
    //{
    //    // Filtrar la lista de productos por la categoría seleccionada
    //    List<Producto> productosFiltrados = new CN_Producto().Listar()
    //        .Where(producto => producto.oCategoria.IdCategoria == idCategoria)
    //        .ToList();

    //    MostrarProductos(productosFiltrados);
    //}
    //private void MostrarTodosLosProductos()
    //{
    //    List<Producto> todosLosProductos = new CN_Producto().Listar();
    //    MostrarProductos(todosLosProductos); // Llamar a la función para mostrar los productos
    //}

    //private void pictureBox3_Click(object sender, EventArgs e)
    //{
    //    this.Hide();
    //    FrmInicioClientes frm = new FrmInicioClientes();
    //    frm.Show();
}

