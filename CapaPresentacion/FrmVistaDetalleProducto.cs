using AForge.Video;
using AForge.Video.DirectShow;
using CapaEntidad;
using CapaNegocio;
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
using ZXing;
using CapaPresentacion.Properties;
using CapaPresentacion.Modales;
using Irony.Parsing;
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CapaPresentacion
{
    public partial class FrmVistaDetalleProducto : Form
    {
        private ActivityTimer activityTimer;

        private CN_Producto objcn_Producto = new CN_Producto();
        public string precioproductodescuento;
        private HashSet<int> productosAgregados = new HashSet<int>();
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private BarcodeReader reader;
        private bool isCameraStarted;
        private bool canScanBarcode = true;

        public FrmVistaDetalleProducto(Producto objProducto = null)
        {
            InitializeComponent();

            reader = new BarcodeReader();

            productoActual = objProducto;
            incrementTimer.Interval = timerInterval;
            incrementTimer.Tick += new EventHandler(incrementimer_Tick);
            decrementTimer.Tick += new EventHandler(decrementimer_Tick);
            isCameraStarted = false;
            CambiarIdioma(IdiomaConfig.Idioma); // Cambiar el idioma al cargar el formulario

            scanDelayTimer = new Timer();
            scanDelayTimer.Interval = 3000; 
            scanDelayTimer.Tick += new EventHandler(scanDelayTimer_Tick);
            scanDelayTimer.Start(); 

            // Habilita la capacidad de escanear cuando se inicia la aplicación.
            canScanBarcode = false;

            activityTimer = ActivityTimer.GetInstance();
            activityTimer.InactivityDetected += ActivityTimer_InactivityDetected;
            activityTimer.Start();


        }
        private Timer incrementTimer = new Timer();
        private int incrementAmount = 0;
        private int timerInterval = 200; // Intervalo inicial del temporizador en milisegundos
        private int maxInterval = 20; // Intervalo máximo para un incremento rápido
        private Timer decrementTimer = new Timer();
        private int decrementAmount = 0;

        private static Producto productoActual;


        private void IniciarCamara()
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
                isCameraStarted = true;

            }
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
                CerrarFormsAbiertos();
                CerrarFormulario();
                activityTimer.Stop();
                this.Dispose();
                this.Close();
            }
        }
        private void CambiarIdioma(string idioma)
        {
            ResourceManager resources = new ResourceManager($"Recursos_{idioma}", typeof(FrmVistaDetalleProducto).Assembly);

            txtCantidad.Text = Rec.Cantidad;
            lblTotalApagartexto.Text = Rec.Total_a_pagar_;
            lbldetalles.Text = Rec.Detalles;
            lbldescripcion.Text = Rec.Descripcion_;
            lblFichaTecnica.Text = Rec.Ficha_tecnica;

        }
        private void InicializarCamara()
        {
            // Enumerar dispositivos de video disponibles
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No se encontraron dispositivos de video.");
                return;
            }

            // Inicializar la cámara con el primer dispositivo disponible si no está instanciada
            if (videoSource == null)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);

            }
            IniciarCamara(); // Iniciar la captura de video al cargar el formulario


        }
        private void RegistrarEscaneoEnBaseDeDatos(int productoId)
        {
            CN_PedidoStock cnConsultas = new CN_PedidoStock();

            PedidoStock escaneo = new PedidoStock
            {
                IdProducto = productoId,
                FechaPedidoStock = DateTime.Now
            };

            bool exito = cnConsultas.RegistrarEscaneoProducto(escaneo);

            if (exito)
            {
                // El escaneo se registró con éxito
            }
            else
            {
                // Hubo un problema al registrar el escaneo, maneja el error apropiadamente
            }
        }
        public Image ByteAImagen(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            Image imagen = Image.FromStream(ms);
            return imagen;
        }
        private void CargarProductosPorSubCategoria2()
        {
            Categoria categoria = new CN_Categoria().Listar().FirstOrDefault(u => u.IdCategoria == productoActual.oCategoria.IdCategoria);
            lblCategoria.Text = categoria.Descripcion;
            bool obtenido = true;
            byte[] byteimagen = new CN_Categoria().ObtenerFotoCategoria(categoria.IdCategoria, out obtenido);

            if (obtenido)
            {
                picCategoria.Image = ByteAImagen(byteimagen);
            }
            SubCategoria subcategoria = new CN_SubCategoria().Listar().FirstOrDefault(u => u.IdSubCategoria == productoActual.oSubCategoria.IdSubCategoria);
            lblSubCategoria.Text = subcategoria.Descripcion;
            bool obtenido2 = true;
            byte[] byteimagen2 = new CN_SubCategoria().ObtenerFotoSubCategoria(subcategoria.IdSubCategoria, out obtenido2);

            if (obtenido2)
            {
                picSubCategoria.Image = ByteAImagen(byteimagen2);
            }
            SubCategoria2 subcategoria2 = new CN_SubCategoria2().Listar().FirstOrDefault(u => u.IdSubCategoria2 == productoActual.oSubCategoria2.IdSubCategoria2);
            lblSubCategoria2.Text = subcategoria2.Descripcion;
            bool obtenido3 = true;
            byte[] byteimagen3 = new CN_SubCategoria2().ObtenerFotoSubCategoria2(subcategoria2.IdSubCategoria2, out obtenido3);

            if (obtenido3)
            {
                picSubCategoria2.Image = ByteAImagen(byteimagen3);
            }
        }
        private void CarritoControl_OnBorrarClicked(object sender, EventArgs e)
        {
            
            // Eliminar el control CarritoControl del FlowLayoutPanel
            CarritoControl control = (CarritoControl)sender;
            panelCarrito.Controls.Remove(control);

            // Eliminar el producto de la lista de compra temporal
            EliminarProductoDeCompraTemp(productoActual.IdProducto.ToString());

            // Recalcular el total a pagar
            CalcularTotalPagar();
        }
        private void FrmVistaDetalleProducto_Load(object sender, EventArgs e)
        {
            CargarProductosPorSubCategoria2();

            foreach (Control control in panelCarrito.Controls)
            {
                if (control is CarritoControl carritoControl)
                {
                    carritoControl.OnBorrarClicked += CarritoControl_OnBorrarClicked;
                }
            }


            MostrarOfertaYCalcularPrecioConDescuento();
            InicializarCamara();
            label3.Click += new EventHandler(label3_Click);

            bool obtenido = true;
            byte[] bytesImagen = new CN_Producto().ObtenerFoto(productoActual.IdProducto, out obtenido);

            if (obtenido)
            {
                Image imagen = ByteAimagen(bytesImagen);
                picFoto.Image = imagen;
            }

            
            txtNombre.Text = productoActual.Nombre;
            txtPrecio.Text = productoActual.PrecioCompra.ToString();
            txtDescripcion.Text = productoActual.Descripcion;
            // Comprobar si los paneles deberían estar visibles según el estado guardado en CompraTemp
            panelCarrito.Visible = CompraTemp.DtgvComprasVisible;
            panelTotalCarrito.Visible = CompraTemp.DtgvComprasVisible;
            panelCabeceraCarrito.Visible = CompraTemp.DtgvComprasVisible;
            // Cargar los datos desde CompraTemp al iniciar el formulario
            CargarProductosEnFlowLayout(); // Agrega esta línea para cargar los productos al cargar el formulario
            CalcularTotalPagar();

        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (canScanBarcode)
            {
                // Actualizar el PictureBox con el nuevo fotograma de la cámara
                pictureBoxCamera.Image = (System.Drawing.Image)eventArgs.Frame.Clone();

                // Decodificar el código de barras
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)eventArgs.Frame.Clone());

                if (result != null)
                {
                    txtCodigoBarras.Invoke((MethodInvoker)delegate
                    {

                        txtCodigoBarras.Text = result.Text;
                    });
                }
            }
        }


        public Image ByteAimagen(byte[] imagenBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes, 0, imagenBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        }


        private void label1_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = productoActual.InformacionNutricional;
            lbldescripcion.Text = "Ficha Tecnica";
            lblFichaTecnica.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            lbldetalles.ForeColor = Color.DimGray;
            label3.ForeColor = Color.DimGray;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            if (Convert.ToInt32(lblcantidad.Text) != 500)
            {
                int cantidad = Convert.ToInt32(lblcantidad.Text);
                cantidad++; // Incrementa en 1

                decimal precioTotal = 0;
                if (lblpreciodescuento.Visible == true)
                {
                    if (decimal.TryParse(precioproductodescuento, out decimal precioConDescuento))
                    {
                        precioTotal = precioConDescuento * cantidad;
                        lblpreciodescuento.Text = precioTotal.ToString();
                    }
                    else
                    {
                        // Manejar el caso donde precioproductodescuento no sea convertible a decimal
                        // Posiblemente mostrar un mensaje de error
                    }
                }
                else
                {
                    precioTotal = Convert.ToDecimal(txtPrecio.Text) + productoActual.PrecioCompra;
                    //txtPrecio.Text = precioTotal.ToString();
                }

                lblcantidad.Text = cantidad.ToString();
            }

        }

        private void btnresta_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            if (Convert.ToInt32(lblcantidad.Text) != 0)
            {
                int cantidad = Convert.ToInt32(lblcantidad.Text);
                cantidad--;

                decimal precioTotal = 0;
                if (lblpreciodescuento.Visible == true)
                {
                    if (decimal.TryParse(precioproductodescuento, out decimal precioConDescuento))
                    {
                        precioTotal = precioConDescuento * cantidad;
                        lblpreciodescuento.Text = precioTotal.ToString();
                    }
                    else
                    {
                        // Manejar el caso donde precioproductodescuento no sea convertible a decimal
                        // Posiblemente mostrar un mensaje de error
                    }
                }
                else
                {
                    precioTotal = Convert.ToDecimal(txtPrecio.Text) + productoActual.PrecioCompra;
                    //txtPrecio.Text = precioTotal.ToString();
                }

                lblcantidad.Text = cantidad.ToString();
            }

        }

        private void incrementimer_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblcantidad.Text) != 500)
            {
                int cantidad = Convert.ToInt32(lblcantidad.Text) + incrementAmount;
                lblcantidad.Text = cantidad.ToString();
            }


            // Aumenta el intervalo gradualmente para acelerar
            if (timerInterval > maxInterval)
            {
                timerInterval--;
                incrementTimer.Interval = timerInterval;
            }
        }

        private void btnsuma_MouseDown(object sender, MouseEventArgs e)
        {
            incrementTimer.Start();
            incrementAmount = 1;
        }
        private void CargarProductosEnFlowLayout()
        {


            foreach (string compraData in CompraTemp.DtgvComprasData)
            {
                string[] data = compraData.Split(';');

                if (data.Length == 5)
                {
                    string idproducto = data[0];
                    string producto = data[1];
                    string cantidad = data[2];
                    string precioCompra = data[3];
                    string oferta = data[4];
                    AgregarProductoAlPanelCarrito(idproducto, producto, cantidad,  precioCompra, oferta);
                }
                

            }
        }
        private void btnsuma_MouseUp(object sender, MouseEventArgs e)
        {
            incrementTimer.Stop();
            incrementAmount = 1;
            // Restablece el intervalo a su valor inicial cuando se suelta el botón
            timerInterval = 200;
            incrementTimer.Interval = timerInterval;
        }

        private void decrementimer_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblcantidad.Text) != 0)
            {
                int cantidad = Convert.ToInt32(lblcantidad.Text) - decrementAmount;
                lblcantidad.Text = cantidad.ToString();
            }


            // Aumenta el intervalo gradualmente para acelerar
            if (timerInterval > maxInterval)
            {
                timerInterval--;
                decrementTimer.Interval = timerInterval;
            }
        }

        private void btnresta_MouseDown(object sender, MouseEventArgs e)
        {
            decrementTimer.Start();
            decrementAmount = 1;
        }

        private void btnresta_MouseUp(object sender, MouseEventArgs e)
        {
            decrementTimer.Stop();
            decrementAmount = 1;
            // Restablece el intervalo a su valor inicial cuando se suelta el botón
            timerInterval = 200;
            decrementTimer.Interval = timerInterval;
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            txtDescripcion.Text = productoActual.InformacionNutricional;
            lbldescripcion.Text = "Ficha Tecnica";
            lblFichaTecnica.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            lbldetalles.ForeColor = Color.DimGray;
            label3.ForeColor = Color.DimGray;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = productoActual.Descripcion;
            lbldescripcion.Text = "Descripcion";
            lblFichaTecnica.ForeColor = Color.DimGray;
            label4.ForeColor = Color.DimGray;
            lbldetalles.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = productoActual.Descripcion;
            lbldescripcion.Text = "Descripcion";
            lblFichaTecnica.ForeColor = Color.DimGray;
            label4.ForeColor = Color.DimGray;
            lbldetalles.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            FrmBusquedaCategoria frm = new FrmBusquedaCategoria();
            frm.Show();
            this.Dispose();
            this.Close();

            scanDelayTimer.Stop();
            IniciarCamara();
            canScanBarcode = true;
            // Detener la cámara si está en ejecución
            DetenerCamara();

            // Liberar los recursos asociados a la cámara
            LiberarRecursosCamara();

            CerrarFormsAbiertos();
        }

        private void FrmVistaDetalleProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            activityTimer.Stop();

            this.Dispose();
            this.Close();
        }
        private void LiberarRecursosCamara()
        {
            if (videoSource != null)
            {
                videoSource.Stop();
                videoSource = null;
            }
        }
        private void DetenerCamara()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                isCameraStarted = false;
            }
        }
        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                isCameraStarted = false;
            }
            string codigo = txtCodigoBarras.Text;
            Producto codbarras = new CN_Producto().Listar().FirstOrDefault(u => u.Codigo == codigo);

            if (codbarras != null)
            {
                this.Dispose();
                this.Close();

                FrmVistaDetalleProducto det = new FrmVistaDetalleProducto(codbarras);
                det.Show();
            }
        }

        private void scanDelayTimer_Tick(object sender, EventArgs e)
        {

            scanDelayTimer.Stop();
            IniciarCamara();
            // Habilita la capacidad de escanear después de que se completa el temporizador de retraso.
            canScanBarcode = true;
        }

        private void MostrarOfertaYCalcularPrecioConDescuento()
        {
            int idProducto = productoActual.IdProducto;
            Producto producto = objcn_Producto.ObtenerProductoConOferta(idProducto);

            if (producto != null && producto.oOferta != null && producto.oOferta.NombreOferta != null)
            {
                lblTextprecio.Visible = true;
                lblOferta.Visible = true;
                lblpreciodescuento.Visible = true;
                panelOfertas.Visible = true;

                // Obtén la oferta del producto actualizado 
                Oferta oferta = producto.oOferta;

                // Mostrar el tipo de oferta en un Label o TextBox
                lblOferta.Text = oferta.NombreOferta;

                // Calcular el precio con descuento directamente
                decimal precioOriginal = productoActual.PrecioCompra; // Precio original del producto
                decimal descuento = oferta.Descuento; // Descuento de la oferta (ajusta esto según tus datos reales)

                decimal precioConDescuento = precioOriginal - (precioOriginal * descuento / 100);

                // Formatear el precio con descuento sin ceros extras
                lblpreciodescuento.Text = precioConDescuento.ToString("0.##"); // Muestra el precio con formato sin ceros extras
                precioproductodescuento = precioConDescuento.ToString("0.##"); // Guarda el precio con descuento

                // Tachar el precio original
                txtPrecio.Font = new Font(txtPrecio.Font, FontStyle.Strikeout);
            }
            else
            {
                // No se encontró una oferta válida para este producto, puedes manejarlo apropiadamente
                lblOferta.Text = ""; // Muestra un mensaje que indique que no hay oferta
                lblpreciodescuento.Text = productoActual.PrecioCompra.ToString("0.##"); // Muestra el precio original

                // Deshacer el tachado del precio original si no hay oferta
                txtPrecio.Font = new Font(txtPrecio.Font, FontStyle.Regular);
            }
        }
        private void EliminarProductoDeCompraTemp(string idProducto)
        {
            // Iterar sobre los datos de la compra temporal y eliminar el producto correspondiente
            for (int i = 0; i < CompraTemp.DtgvComprasData.Count; i++)
            {
                string[] data = CompraTemp.DtgvComprasData[i].Split(';');

                if (data.Length == 5 && data[0] == idProducto)
                {
                    CompraTemp.DtgvComprasData.RemoveAt(i);
                    return;
                }
            }
        }
        private void ActualizarCantidadEnCompraTemp(string idProducto, string nuevaCantidad)
        {
            // Iterar sobre los datos de la compra temporal y actualizar la cantidad del producto
            for (int i = 0; i < CompraTemp.DtgvComprasData.Count; i++)
            {
                string[] data = CompraTemp.DtgvComprasData[i].Split(';');

                if (data.Length == 5 && data[0] == idProducto)
                {
                    CompraTemp.DtgvComprasData[i] = $"{idProducto};{data[1]};{nuevaCantidad};{data[3]};{data[4]}";
                    return;
                }
            }
        }

        private void PicBorrar_Click(object sender, EventArgs e)
        {
            // Identifica el control CarritoControl asociado al evento
            CarritoControl productoControl = (CarritoControl)sender;

            // Remueve el control CarritoControl del panelCarrito
            panelCarrito.Controls.Remove(productoControl);

            // Eliminar el producto de la lista de productos agregados
            productosAgregados.Remove(Convert.ToInt32(productoControl.Id));

            // Eliminar el producto de CompraTemp
            EliminarProductoDeCompraTemp(productoControl.Id);
            CalcularTotalPagar();
        }
        private void AgregarProductoAlPanelCarrito(string idproducto, string producto, string cantidad, string precioCompra, string oferta)
        {
            CarritoControl productoControl = new CarritoControl();
            productoControl.Id = idproducto;
            productoControl.Titulo = producto;
            productoControl.Cantidad = cantidad;
            productoControl.PrecioCompra = precioCompra;
            productoControl.Oferta = oferta;

            // Cargar la imagen del producto si es necesario
            bool obtenido = true;
            byte[] bytesImagen = new CN_Producto().ObtenerFoto(Convert.ToInt32(idproducto), out obtenido);
            if (obtenido)
            {
                Image imagen = ByteAimagen(bytesImagen);
                productoControl.Foto = imagen;
            }

            productoControl.OnBorrarClicked += PicBorrar_Click;

            panelCarrito.Controls.Add(productoControl);
        }
        private void GuardarProductoEnCompraTemp(string idproducto, string producto, string cantidad, string precioCompra, string oferta)
        {
            // Construye una cadena con los datos separados por comas
            string compraData = $"{idproducto};{producto};{cantidad};{precioCompra};{oferta}";

            // Verifica si la compraData ya existe en la lista antes de agregarla
            if (!CompraTemp.DtgvComprasData.Contains(compraData))
            {
                CompraTemp.DtgvComprasData.Add(compraData);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            // Ocultar el panel de carrito y otros elementos
            panelTotalCarrito.Visible = false;
            panelCarrito.Visible = false;
            CompraTemp.DtgvComprasData.Clear();

            // Eliminar todos los controles hijos del FlowLayoutPanel, excepto el panelCabeceraCarrito
            foreach (Control control in panelCarrito.Controls.OfType<Control>().ToList())
            {
                if (control.Name != "panelCabeceraCarrito")
                {
                    panelCarrito.Controls.Remove(control);
                    control.Dispose(); // Liberar recursos del control eliminado
                }
            }

            // Volver a cargar los productos en el FlowLayoutPanel
            CargarProductosEnFlowLayout();
            CalcularTotalPagar();

        }
        private void CalcularTotalPagar()
        {
            decimal totalPagar = 0;

            foreach (Control control in panelCarrito.Controls)
            {
                if (control is CarritoControl carritoControl)
                {
                    // Verificar si la cadena es un número decimal válido
                    if (decimal.TryParse(carritoControl.PrecioCompra, out decimal precio))
                    {
                        // Sumar el precio al total a pagar
                        totalPagar += precio * decimal.Parse(carritoControl.Cantidad);
                    }
                    else
                    {
                        // Manejar el caso donde el precio no es un número decimal válido
                        MessageBox.Show("Error: El precio del producto no es válido.");
                        return;
                    }
                }
            }

            // Actualizar el valor total a pagar en el control lblTotalPagar
            txtTotalPagar.Text = totalPagar.ToString();
        }
        private void CerrarFormsAbiertos()
        {
            activityTimer.Stop();
            // Crear una lista para almacenar los formularios que se deben cerrar
            List<Form> formsACerrar = new List<Form>();

            // Recorrer todos los formularios abiertos en la aplicación
            foreach (Form frm in Application.OpenForms)
            {
                // Verificar si el formulario es del tipo FrmVistaDetalleProducto y no es el formulario actual
                if (frm is FrmVistaDetalleProducto && frm != this)
                {
                    // Agregar el formulario a la lista de formularios que se deben cerrar
                    formsACerrar.Add(frm);
                }
            }

            // Cerrar todos los formularios almacenados en la lista
            foreach (Form frmCerrar in formsACerrar)
            {
                frmCerrar.Close();
                frmCerrar.Dispose();
                CerrarFormulario();

            }
        }
        private void CerrarFormulario()
        {
            // Detener la cámara si está en ejecución
            DetenerCamara();

            // Liberar los recursos asociados a la cámara
            LiberarRecursosCamara();

            // Cerrar el formulario
            this.Dispose();
            this.Close();

        }
        private void FrmVistaDetalleProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarFormsAbiertos();
            CerrarFormulario();
            activityTimer.Stop();

            this.Dispose();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            RegistrarEscaneoEnBaseDeDatos(productoActual.IdProducto);
            MessageBox.Show("Pedido de stock del producto con exito, muchas gracias!");
            pictureBox4.Enabled = false;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            // Asegurarse de que lblcantidad.Text contenga un valor numérico válido
            if (!int.TryParse(lblcantidad.Text, out int cantidadProducto))
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            // Mostrar el panel de carrito y otros elementos
            panelCarrito.Visible = true;
            panelTotalCarrito.Visible = true;
            panelCabeceraCarrito.Visible = true;

            // Obtener los datos del producto actual
            string idProducto = productoActual.IdProducto.ToString();
            string nombreProducto = txtNombre.Text;
            string precioProducto = lblpreciodescuento.Visible ? precioproductodescuento : txtPrecio.Text;
            string ofertaProducto = lblOferta.Text;

            // Verificar si el producto ya está en el carrito
            bool productoExistente = false;
            foreach (Control control in panelCarrito.Controls)
            {
                if (control is CarritoControl productoControl && productoControl.Id == idProducto)
                {
                    // Actualizar la cantidad del producto
                    productoControl.Cantidad = (int.Parse(productoControl.Cantidad) + cantidadProducto).ToString();

                    // Actualizar los datos en CompraTemp
                    ActualizarCantidadEnCompraTemp(idProducto, productoControl.Cantidad);

                    // Indicar que el producto ya está en el carrito
                    productoExistente = true;
                    break;
                }
            }

            // Si el producto no está en el carrito, agregarlo
            if (!productoExistente)
            {
                // Agregar el ID del producto al HashSet
                productosAgregados.Add(productoActual.IdProducto);

                // Agregar los datos del producto al PanelCarrito
                AgregarProductoAlPanelCarrito(idProducto, nombreProducto, cantidadProducto.ToString(), precioProducto, ofertaProducto);

                // Guardar los datos del producto en CompraTemp
                GuardarProductoEnCompraTemp(idProducto, nombreProducto, cantidadProducto.ToString(), precioProducto, ofertaProducto);
            }

            // Actualizar la visibilidad en CompraTemp
            CompraTemp.DtgvComprasVisible = true;

            // Recalcular el precio total con descuento
            CalcularTotalPagar();

            // Restablecer la cantidad a cero
            lblcantidad.Text = "0";
        }

        private void panelCarrito_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void panelOfertas_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void panelCabeceraCarrito_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void flowLayoutPanel2_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

       

        private void panel14_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }
    }
}
