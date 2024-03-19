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
        private ActivityTimer activityTimer;

        private List<byte[]> fotosOfertas;
        private int ofertaActualIndex;
        private int idSubCategoriaSeleccionada;
        private int idSubCategoria2Seleccionada;
        private int idCategoriaSeleccionada;

        public int IdOferta { get; set; }
        public FrmBusquedaCategoria()
        {
            InitializeComponent();
            activityTimer = ActivityTimer.GetInstance();
            activityTimer.InactivityDetected += ActivityTimer_InactivityDetected;
            activityTimer.Start();
        }
        private void ActivityTimer_InactivityDetected(object sender, EventArgs e)
        {
            // Se detectó inactividad, mostrar el formulario de confirmación
            MyMessageBoxForm messageBoxForm = new MyMessageBoxForm();
            DialogResult result = messageBoxForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                activityTimer.Stop();
                activityTimer.Start();
            }
            else
            {
                // El usuario no respondió o confirmó que no está activo, cerrar sesión y volver a la pantalla principal
                // Realiza aquí las acciones para cerrar la sesión y volver a la pantalla principal
                FrmPantallaPrincipalClientes frmPantallaPrincipal = new FrmPantallaPrincipalClientes();
                frmPantallaPrincipal.Show();
                this.Dispose();
                this.Close();
            }
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
            activityTimer.Stop();
            FrmVistaDetalleProducto detalleform = new FrmVistaDetalleProducto(producto);
            detalleform.Show();
            this.Close();
            this.Dispose();

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
                activityTimer.Stop();
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
            activityTimer.Stop();
            this.Close();
            this.Dispose();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();

        }
        private void CategoriaControl_ClicEnFotoCategoria(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();

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
            activityTimer.Stop();
            activityTimer.Start();
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
            activityTimer.Stop();
            activityTimer.Start();
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
            activityTimer.Stop();
            activityTimer.Start();

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
        



        private void lblsiguienteproductos_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBusquedaCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            activityTimer.Stop();
            this.Dispose();
            this.Close();


        }

        private void lblSubCategoria2_Click_1(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void lblSubCategoria_Click_1(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
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

        private void lblCategoria_Click_1(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
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

        private void lblProductos_Click_1(object sender, EventArgs e)
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
                CargarProductosEnFlowLayout();

            }


        }

        private void flowpanelProductos_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void FrmBusquedaCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            activityTimer.Stop();
            this.Dispose();
            this.Close();
        }
    }

   
}

