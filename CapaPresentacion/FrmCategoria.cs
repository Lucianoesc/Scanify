using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using Irony.Parsing;
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
    public partial class FrmCategoria : Form
    {
        private static FrmCategoria instance;
        public static FrmCategoria Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new FrmCategoria();
                return instance;
            }
        }
        private int idSubCategoriaSeleccionada;
        private int idSubCategoria2Seleccionada;

        private int idCategoriaSeleccionada;
        public FrmCategoria()
        {
            InitializeComponent();
            
        }
        public void Frm_Actualizador(object sender, EventArgs e)
        {
            // Actualizar los productos en el FlowLayoutPanel
            CargarProductosEnFlowLayout();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            foreach (CategoriaControl cartaControl in flowLayoutPanel1.Controls.OfType<CategoriaControl>())
            {
                cartaControl.Actualizador += Frm_Actualizador;
            }

            // Cargar los productos en el FlowLayoutPanel
            CargarProductosEnFlowLayout();

            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);


            foreach (CategoriaControl categoriaControl in flowLayoutPanel1.Controls.OfType<CategoriaControl>())
            {
                categoriaControl.ClicEnFotoCategoria += CategoriaControl_ClicEnFotoCategoria;
            }
            foreach (SubCategoriaControl subcategoriaControl in flowLayoutPanel1.Controls.OfType<SubCategoriaControl>())
            {
                subcategoriaControl.ClicEnFotoSubCategoria += SubCategoriaControl_ClicEnFotoSubCategoria;
            }
            foreach (SubCategoriaControl subcategoriaControl in flowLayoutPanel1.Controls.OfType<SubCategoriaControl>())
            {
                subcategoriaControl.SubCategoriaActualizada += SubCategoriaControl_Actualizar;
            }
            foreach (SubCategoria2Control subcategoria2Control in flowLayoutPanel1.Controls.OfType<SubCategoria2Control>())
            {
                subcategoria2Control.SubCategoria2Actualizada += SubCategoria2Control_Actualizar;
            }
            foreach (SubCategoria2Control subcategoria2Control in flowLayoutPanel1.Controls.OfType<SubCategoria2Control>())
            {
                subcategoria2Control.SubCategoria2Seleccionada += SubCategoria2Control_SubCategoria2Seleccionada;
            }
            foreach (CartaControl cartaControl in flowLayoutPanel1.Controls.OfType<CartaControl>())
            {
                cartaControl.ProductosActualizados += Frm_ProductosActualizados;
            }
        }
        private void SubCategoria2Control_SubCategoria2Seleccionada(object sender, EventArgs e)
        {
            if (sender is SubCategoria2Control subcategoria2Control)
            {

                int idSubCategoria2 = Convert.ToInt32(subcategoria2Control.Id);
                lblSiguienteSubCat2.Visible = true;
                lblSubCategoria2.Text = subcategoria2Control.Titulo;
                lblSubCategoria2.Visible = true;
                lblSiguienteSubCat2.BringToFront();

                lblSubCategoria2.BringToFront();
                CargarProductosPorSubCategoria2(idSubCategoria2);
            }
        }

        private void CargarProductosPorSubCategoria2(int idSubCategoria2)
        {

            btnSubCategoria2.Visible = false;
            btnProducto.Visible = true;
            txtBuscador.Visible = false;
            txtBuscadorProductos.Visible = true;
            txtBuscadorSubCategorias.Visible = false;
            txtBuscadorSubCategorias2.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            foreach (Control control in flowLayoutPanel1.Controls.OfType<CartaControl>().ToList())
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            // Resto del método permanece igual
            // Crear una instancia de la capa de negocio de productos
            CN_Producto negocioProducto = new CN_Producto();
            idSubCategoria2Seleccionada = idSubCategoria2;
            // Obtener la lista de productos por el ID de la subcategoría 2
            List<Producto> listaProductos = negocioProducto.ListarProductosPorIdSubCategoria2(idSubCategoria2);

            // Recorrer la lista de productos y agregar controles correspondientes al FlowLayoutPanel
            foreach (Producto producto in listaProductos)
            {
                // Crear un control visual para mostrar cada producto en el FlowLayoutPanel
                CartaControl productoControl = new CartaControl();
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
                
                productoControl.ProductosActualizados += Frm_ProductosActualizados;

                // Agregar el productoControl al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(productoControl);
            }
        }
        private void SubCategoriaControl_Actualizar(object sender, EventArgs e)
        {
            btnSubCategoria2.Visible = false;
            btnCategorias.Visible = false;
            btnSubCategoria.Visible = true;
            // Verificar si el evento proviene del control SubCategoriaControl o del formulario modal Md_SubCategoria
            if (sender is SubCategoriaControl categoriaSeleccionada)
            {
                // Si el evento proviene del control SubCategoriaControl

                // Obtener el ID de la categoría seleccionada y almacenarlo en la variable
                idCategoriaSeleccionada = Convert.ToInt32(categoriaSeleccionada.IdCategoria);
            }
            else if (sender is Md_SubCategoria formularioModal)
            {
                // Si el evento proviene del formulario modal Md_SubCategoria

                // Obtener el ID de la categoría seleccionada desde el formulario modal
                idCategoriaSeleccionada = formularioModal.IdCategoriaSeleccionada;
            }
            // Resto del código omitido por brevedad
            // Limpiar el FlowLayoutPanel antes de cargar las subcategorías
            flowLayoutPanel1.Controls.Clear();

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria negocioSubCategoria = new CN_SubCategoria();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria> listaSubcategorias = negocioSubCategoria.ListarPorIdCategoria(idCategoriaSeleccionada);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria subcategoria in listaSubcategorias)
            {
                SubCategoriaControl subcategoriaControl = new SubCategoriaControl(); // Aquí debería ser CategoriaControl en lugar de SubCategoriaControl
                subcategoriaControl.Id = subcategoria.IdSubCategoria.ToString();
                subcategoriaControl.Titulo = subcategoria.Descripcion;
                subcategoriaControl.IdCategoria = subcategoria.oCategoria.IdCategoria.ToString();
                subcategoriaControl.Estado = subcategoria.Estado ? "Activo" : "Inactivo";
                subcategoriaControl.Foto = ByteAimagen(subcategoria.FotoSubCategoria);
                subcategoriaControl.SubCategoriaActualizada += SubCategoriaControl_Actualizar;
                subcategoriaControl.ClicEnFotoSubCategoria += SubCategoriaControl_ClicEnFotoSubCategoria;

                flowLayoutPanel1.Controls.Add(subcategoriaControl);
            }
        }
        private void SubCategoria2Control_Actualizar(object sender, EventArgs e)
        {
            btnSubCategoria2.Visible = true;
            btnCategorias.Visible = false;
            btnSubCategoria.Visible = false;

            // Verificar si el evento proviene del control SubCategoriaControl o del formulario modal Md_SubCategoria
            if (sender is SubCategoria2Control subcategoriaSeleccionada)
            {
                // Si el evento proviene del control SubCategoriaControl

                // Obtener el ID de la categoría seleccionada y almacenarlo en la variable
                idSubCategoriaSeleccionada = Convert.ToInt32(subcategoriaSeleccionada.IdSubCategoria);
            }
            else if (sender is Md_SubCategoria2 formularioModal)
            {
                // Si el evento proviene del formulario modal Md_SubCategoria

                // Obtener el ID de la categoría seleccionada desde el formulario modal
                idSubCategoriaSeleccionada = formularioModal.IdSubCategoriaSeleccionada;
            }
            // Resto del código omitido por brevedad
            // Limpiar el FlowLayoutPanel antes de cargar las subcategorías
            flowLayoutPanel1.Controls.Clear();

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria2 negocioSubCategoria2 = new CN_SubCategoria2();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria2> listaSubcategorias2 = negocioSubCategoria2.ListarPorIdSubCategoria(idSubCategoriaSeleccionada);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria2 subcategoria2 in listaSubcategorias2)
            {
                SubCategoria2Control subcategoriaControl = new SubCategoria2Control(); // Aquí debería ser CategoriaControl en lugar de SubCategoriaControl
                subcategoriaControl.Id = subcategoria2.IdSubCategoria2.ToString();
                subcategoriaControl.Titulo = subcategoria2.Descripcion;
                subcategoriaControl.IdSubCategoria = subcategoria2.oSubCategoria.IdSubCategoria.ToString();
                subcategoriaControl.Estado = subcategoria2.Estado ? "Activo" : "Inactivo";
                subcategoriaControl.Foto = ByteAimagen(subcategoria2.FotoSubCategoria2);
                subcategoriaControl.SubCategoria2Actualizada += SubCategoria2Control_Actualizar;
                flowLayoutPanel1.Controls.Add(subcategoriaControl);
            }
        }
        private void CategoriaControl_ClicEnFotoCategoria(object sender, EventArgs e)
        {

            CategoriaControl categoriaSeleccionada = (CategoriaControl)sender;

            // Obtener el ID de la categoría seleccionada y almacenarlo en la variable
            idCategoriaSeleccionada = Convert.ToInt32(categoriaSeleccionada.Id);
            btnCategorias.Visible = false;
            btnSubCategoria.Visible = true;
            btnSubCategoria2.Visible = false;
            txtBuscador.Visible = false;
            txtBuscadorProductos.Visible = false;
            txtBuscadorSubCategorias.Visible = true;
            txtBuscadorSubCategorias2.Visible = false;
            // Obtener el ID de la categoría seleccionada

            // Limpiar el FlowLayoutPanel antes de cargar las subcategorías
            flowLayoutPanel1.Controls.Clear();

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria negocioSubCategoria = new CN_SubCategoria();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria> listaSubcategorias = negocioSubCategoria.ListarPorIdCategoria(idCategoriaSeleccionada);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria subcategoria in listaSubcategorias)
            {
                SubCategoriaControl subcategoriaControl = new SubCategoriaControl(); // Aquí debería ser CategoriaControl en lugar de SubCategoriaControl
                subcategoriaControl.Id = subcategoria.IdSubCategoria.ToString();
                subcategoriaControl.Titulo = subcategoria.Descripcion;
                subcategoriaControl.IdCategoria = subcategoria.oCategoria.IdCategoria.ToString();
                subcategoriaControl.Estado = subcategoria.Estado ? "Activo" : "Inactivo";
                subcategoriaControl.Foto = ByteAimagen(subcategoria.FotoSubCategoria);
                subcategoriaControl.SubCategoriaActualizada += SubCategoriaControl_Actualizar;
                subcategoriaControl.ClicEnFotoSubCategoria += SubCategoriaControl_ClicEnFotoSubCategoria;
                lblsiguienteproductos.Visible = true;

                lblCategoria.Visible = true;
                lblCategoria.Text = categoriaSeleccionada.Titulo;
                lblCategoria.BringToFront();

                lblCategoria.BringToFront();
                flowLayoutPanel1.Controls.Add(subcategoriaControl);
            }
        }
        private void SubCategoriaControl_ClicEnFotoSubCategoria(object sender, EventArgs e)
        {
            btnCategorias.Visible = false;

            btnSubCategoria.Visible = false;
            btnSubCategoria2.Visible = true;
            txtBuscador.Visible = false;
            txtBuscadorProductos.Visible = false;
            txtBuscadorSubCategorias.Visible = false;
            txtBuscadorSubCategorias2.Visible = true;

            SubCategoriaControl subcategoriaSeleccionada = (SubCategoriaControl)sender;

            // Obtener el ID de la categoría seleccionada y almacenarlo en la variable
            idSubCategoriaSeleccionada = Convert.ToInt32(subcategoriaSeleccionada.Id);


            // Obtener el ID de la categoría seleccionada

            // Limpiar el FlowLayoutPanel antes de cargar las subcategorías
            flowLayoutPanel1.Controls.Clear();

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria2 negocioSubCategoria2 = new CN_SubCategoria2();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria2> listaSubcategorias2 = negocioSubCategoria2.ListarPorIdSubCategoria(idSubCategoriaSeleccionada);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria2 subcategoria2 in listaSubcategorias2)
            {
                SubCategoria2Control subcategoria2Control = new SubCategoria2Control(); // Aquí debería ser CategoriaControl en lugar de SubCategoriaControl
                subcategoria2Control.Id = subcategoria2.IdSubCategoria2.ToString();
                subcategoria2Control.Titulo = subcategoria2.Descripcion;
                subcategoria2Control.IdSubCategoria = subcategoria2.oSubCategoria.IdSubCategoria.ToString();
                subcategoria2Control.Estado = subcategoria2.Estado ? "Activo" : "Inactivo";
                subcategoria2Control.Foto = ByteAimagen(subcategoria2.FotoSubCategoria2);
                subcategoria2Control.SubCategoria2Actualizada += SubCategoria2Control_Actualizar;
                subcategoria2Control.SubCategoria2Seleccionada += SubCategoria2Control_SubCategoria2Seleccionada;
                lblSubCategoria.Text = subcategoriaSeleccionada.Titulo;
                lblSiguienteSubCat.Visible = true;
                lblSubCategoria.Visible = true;
                lblSiguienteSubCat.BringToFront();

                lblSubCategoria.BringToFront();

                flowLayoutPanel1.Controls.Add(subcategoria2Control);
            }
        }
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                using (Md_Categoria frm = new Md_Categoria())
                {
                    frm.Actualizador += Frm_Actualizador;

                    background.StartPosition = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = Color.Black;
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
        private void CargarProductosEnFlowLayout()
        {
            // Limpiar el FlowLayoutPanel antes de cargar los productos
            flowLayoutPanel1.Controls.Clear();

            // Crear una instancia de la capa de negocio de producto
            CN_Categoria negocioCategoria = new CN_Categoria();

            // Obtener la lista de productos utilizando el método Listar de CN_Producto
            List<Categoria> lista = negocioCategoria.Listar();

            // Recorrer la lista de productos
            foreach (Categoria categoria in lista)
            {
                CategoriaControl categoriaControl = new CategoriaControl();
                categoriaControl.Id = categoria.IdCategoria.ToString();
                categoriaControl.Titulo = categoria.Descripcion;
                categoriaControl.Estado = categoria.Estado ? "Activo" : "Inactivo";
                categoriaControl.Foto = ByteAimagen(categoria.FotoCategoria);
                categoriaControl.Actualizador += Frm_Actualizador;
                categoriaControl.ClicEnFotoCategoria += CategoriaControl_ClicEnFotoCategoria;


                flowLayoutPanel1.Controls.Add(categoriaControl);
            }
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscador.Text.Trim().ToUpper();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CategoriaControl cartaControl)
                {
                    // Verificar si el título o el código del producto contienen el texto de búsqueda
                    bool encontrado = cartaControl.Titulo.ToUpper().Contains(textoBusqueda) ||
                                      cartaControl.Id.ToUpper().Contains(textoBusqueda);

                    // Mostrar u ocultar el control según el término de búsqueda
                    cartaControl.Visible = encontrado;
                }
            }
        }

        private void btnSubCategoria_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                using (Md_SubCategoria frm = new Md_SubCategoria(idCategoriaSeleccionada))
                {
                    frm.SubCategoriaActualizada += SubCategoriaControl_Actualizar;


                    background.StartPosition = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = Color.Black;
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
                background.Dispose();
            }
        }

        private void btnSubCategoria2_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                using (Md_SubCategoria2 frm = new Md_SubCategoria2(idSubCategoriaSeleccionada))
                {
                    frm.SubCategoria2Actualizada += SubCategoria2Control_Actualizar;


                    background.StartPosition = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = Color.Black;
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
                background.Dispose();
            }
        }

        private void txtBuscadorSubCategorias_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscadorSubCategorias.Text.Trim().ToUpper();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is SubCategoriaControl cartaControl)
                {
                    // Verificar si el título o el código del producto contienen el texto de búsqueda
                    bool encontrado = cartaControl.Titulo.ToUpper().Contains(textoBusqueda) ||
                                      cartaControl.Id.ToUpper().Contains(textoBusqueda);

                    // Mostrar u ocultar el control según el término de búsqueda
                    cartaControl.Visible = encontrado;
                }
            }
        }

        private void txtBuscadorSubCategorias2_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscadorSubCategorias2.Text.Trim().ToUpper();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is SubCategoria2Control cartaControl)
                {
                    // Verificar si el título o el código del producto contienen el texto de búsqueda
                    bool encontrado = cartaControl.Titulo.ToUpper().Contains(textoBusqueda) ||
                                      cartaControl.Id.ToUpper().Contains(textoBusqueda);

                    // Mostrar u ocultar el control según el término de búsqueda
                    cartaControl.Visible = encontrado;
                }
            }
        }

        private void txtBuscadorProductos_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscadorProductos.Text.Trim().ToUpper();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CartaControl cartaControl)
                {
                    // Verificar si el título o el código del producto contienen el texto de búsqueda
                    bool encontrado = cartaControl.Titulo.ToUpper().Contains(textoBusqueda) ||
                                      cartaControl.Id.ToUpper().Contains(textoBusqueda);

                    // Mostrar u ocultar el control según el término de búsqueda
                    cartaControl.Visible = encontrado;
                }
            }
        }
        private void CargarProductos(int idSubCategoria2Seleccionada)
        {
            btnSubCategoria2.Visible = false;
            btnProducto.Visible = true;
            txtBuscador.Visible = false;
            txtBuscadorProductos.Visible = true;
            txtBuscadorSubCategorias.Visible = false;
            txtBuscadorSubCategorias2.Visible = false;
            flowLayoutPanel1.Controls.Clear();




            // Resto del método permanece igual
            // Crear una instancia de la capa de negocio de productos
            CN_Producto negocioProducto = new CN_Producto();

            // Obtener la lista de productos por el ID de la subcategoría 2
            List<Producto> listaProductos = negocioProducto.ListarProductosPorIdSubCategoria2(idSubCategoria2Seleccionada);

            // Recorrer la lista de productos y agregar controles correspondientes al FlowLayoutPanel
            foreach (Producto producto in listaProductos)
            {
                // Crear un control visual para mostrar cada producto en el FlowLayoutPanel
                CartaControl productoControl = new CartaControl();
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

                productoControl.ProductosActualizados += Frm_ProductosActualizados;

                // Agregar el productoControl al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(productoControl);
            }
        }
        private void Frm_ProductosActualizados(object sender, EventArgs e)
        {

            CargarProductos(idSubCategoria2Seleccionada);
            btnProducto.Visible = true;

        }
        private void btnProducto_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            try
            {
                using (ModalControladorProductos frm = new ModalControladorProductos(idCategoriaSeleccionada,idSubCategoriaSeleccionada, idSubCategoria2Seleccionada))
                {
                    frm.ProductosActualizados += Frm_ProductosActualizados;

                    background.StartPosition = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = Color.Black;
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
                background.Dispose();
            }

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {
            btnCategorias.Visible = false;
            btnSubCategoria.Visible = true;
            btnSubCategoria2.Visible = false;
            txtBuscador.Visible = false;
            txtBuscadorProductos.Visible = false;
            txtBuscadorSubCategorias.Visible = true;
            txtBuscadorSubCategorias2.Visible = false;
            // Limpiar los controles dentro de flowpanelProductos y flowpanelCategorias
            flowLayoutPanel1.Controls.Clear();

            // Obtener el ID de la categoría seleccionada
            int idCategoria = idCategoriaSeleccionada;

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria negocioSubCategoria = new CN_SubCategoria();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria> listaSubcategorias = negocioSubCategoria.ListarPorIdCategoria(idCategoria);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria subcategoria in listaSubcategorias)
            {
                SubCategoriaControl subcategoriaControl = new SubCategoriaControl();
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
                flowLayoutPanel1.Controls.Add(subcategoriaControl);
            }
        }

        private void lblSubCategoria_Click(object sender, EventArgs e)
        {
            btnCategorias.Visible = false;
            btnSubCategoria.Visible = false;
            btnSubCategoria2.Visible = true;
            txtBuscador.Visible = false;
            txtBuscadorProductos.Visible = false;
            txtBuscadorSubCategorias.Visible = false;
            txtBuscadorSubCategorias2.Visible = true;

            flowLayoutPanel1.Controls.Clear();

            // Obtener el ID de la categoría seleccionada
            int idSubCategoria = idSubCategoriaSeleccionada;

            // Crear una instancia de la capa de negocio de subcategoría
            CN_SubCategoria2 negocioSubCategoria2 = new CN_SubCategoria2();

            // Obtener la lista de subcategorías por el ID de la categoría seleccionada
            List<SubCategoria2> listaSubcategorias2 = negocioSubCategoria2.ListarPorIdSubCategoria(idSubCategoria);

            // Recorrer la lista de subcategorías
            foreach (SubCategoria2 subcategoria2 in listaSubcategorias2)
            {
                SubCategoria2Control subcategoria2Control = new SubCategoria2Control();
                subcategoria2Control.Id = subcategoria2.IdSubCategoria2.ToString();
                subcategoria2Control.Titulo = subcategoria2.Descripcion;
                subcategoria2Control.IdSubCategoria = subcategoria2.oSubCategoria.IdSubCategoria.ToString();
                subcategoria2Control.Estado = subcategoria2.Estado ? "Activo" : "Inactivo";
                subcategoria2Control.Foto = ByteAimagen(subcategoria2.FotoSubCategoria2);
                subcategoria2Control.SubCategoria2Seleccionada += SubCategoria2Control_SubCategoria2Seleccionada;
                lblSiguienteSubCat2.Visible = false;
                lblSubCategoria2.Visible = false;
                lblSiguienteSubCat.Visible = true;
                lblSubCategoria2.BringToFront();
                flowLayoutPanel1.Controls.Add(subcategoria2Control);
            }
        }

        private void lblSubCategoria2_Click(object sender, EventArgs e)
        {

        }

        private void lblTodaslascategorias_Click(object sender, EventArgs e)
        {
            if (lblsiguienteproductos.Visible == true)
            {
                txtBuscador.Visible = true;
                txtBuscadorSubCategorias.Visible = false;
                txtBuscadorSubCategorias2.Visible = false;
                txtBuscadorProductos.Visible = false;
                btnCategorias.Visible = true;
                btnSubCategoria.Visible = false;
                btnProducto.Visible = false;
                btnSubCategoria2.Visible = false;

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
    }
}
