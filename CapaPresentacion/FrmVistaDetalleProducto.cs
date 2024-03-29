﻿using AForge.Video;
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

namespace CapaPresentacion
{
    public partial class FrmVistaDetalleProducto : Form
    {
        private CN_Producto objcn_Producto = new CN_Producto();

        public Form PreviousForm { get; set; }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private BarcodeReader reader;
        private bool isCameraStarted;
        private bool canScanBarcode = true;


        public FrmVistaDetalleProducto(Producto objProducto)
        {
            InitializeComponent();
            CargarDatosDesdeCompraTemp();

            dtgvCompra.Visible = CompraTemp.DtgvComprasVisible;

            reader = new BarcodeReader();
            productoActual = objProducto;
            incrementTimer.Interval = timerInterval;
            incrementTimer.Tick += new EventHandler(incrementimer_Tick);
            decrementTimer.Tick += new EventHandler(decrementimer_Tick);
            isCameraStarted = false;

            scanDelayTimer = new Timer();
            scanDelayTimer.Interval = 3000; // 10 segundos
            scanDelayTimer.Tick += new EventHandler(scanDelayTimer_Tick);
            scanDelayTimer.Start(); // Asegúrate de habilitar el temporizador

            // Habilita la capacidad de escanear cuando se inicia la aplicación.
            canScanBarcode = false;




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
        private void FrmVistaDetalleProducto_Load(object sender, EventArgs e)
        {


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
            txtCategoria.Text = productoActual.oCategoria.Descripcion;

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
            label6.Text = "Ficha Tecnica";
            label1.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label2.ForeColor = Color.DimGray;
            label3.ForeColor = Color.DimGray;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {



            if (Convert.ToInt32(lblcantidad.Text) != 500)
            {
                int cantidad = Convert.ToInt32(lblcantidad.Text);
                cantidad++; // Incrementa en 1

                decimal precioCompra = productoActual.PrecioCompra;
                decimal precioTotal = precioCompra * cantidad;
                txtPrecio.Text = precioTotal.ToString();
                // Actualiza el texto del label
                lblcantidad.Text = cantidad.ToString();
            }


        }

        private void CargarDatosDesdeCompraTemp()
        {
            foreach (string compraData in CompraTemp.DtgvComprasData)
            {
                string[] data = compraData.Split(',');

                if (data.Length == 5)
                {
                    string cantidad = data[0];
                    string producto = data[1];
                    string precioCompra = data[2];
                    string oferta = data[4];
                    dtgvCompra.Rows.Add(cantidad, producto, precioCompra, oferta);
                }
            }
        }

        private void btnresta_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblcantidad.Text) != 0)
            {
                int cantidad = Convert.ToInt32(lblcantidad.Text);
                cantidad--;

                decimal precioCompra = productoActual.PrecioCompra;
                decimal precioTotal = precioCompra * cantidad;
                txtPrecio.Text = precioTotal.ToString();
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

        private void panel4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            txtDescripcion.Text = productoActual.InformacionNutricional;
            label6.Text = "Ficha Tecnica";
            label1.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label2.ForeColor = Color.DimGray;
            label3.ForeColor = Color.DimGray;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = productoActual.Descripcion;
            label6.Text = "Descripcion";
            label1.ForeColor = Color.DimGray;
            label4.ForeColor = Color.DimGray;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = productoActual.Descripcion;
            label6.Text = "Descripcion";
            label1.ForeColor = Color.DimGray;
            label4.ForeColor = Color.DimGray;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {


            scanDelayTimer.Stop();
            IniciarCamara();
            // Habilita la capacidad de escanear después de que se completa el temporizador de retraso.
            canScanBarcode = true;
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                isCameraStarted = false;
            }
            this.Close(); // Oculta el formulario de búsqueda

            PreviousForm.Show(); // Muestra el formulario anterior
        }

        private void FrmVistaDetalleProducto_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Guarda el estado de visibilidad en la clase CompraTemp
                CompraTemp.DtgvComprasVisible = dtgvCompra.Visible;

                // Si la lista actual de datos de compra aún no existe, créala
                if (CompraTemp.DtgvComprasData == null)
                {
                    CompraTemp.DtgvComprasData = new List<string>();
                }

                // Luego, verifica si los datos ya existen en la lista antes de agregarlos
                foreach (DataGridViewRow row in dtgvCompra.Rows)
                {
                    string cantidad = row.Cells[0].Value?.ToString() ?? "";
                    string producto = row.Cells[1].Value?.ToString() ?? "";
                    string precioCompra = row.Cells[2].Value?.ToString() ?? "";
                    string oferta = row.Cells[3].Value?.ToString() ?? "";

                    // Construye una cadena con los datos separados por comas
                    string compraData = $"{cantidad},{producto},{precioCompra},{oferta}";

                    // Verifica si la compraData ya existe en la lista antes de agregarla
                    if (!CompraTemp.DtgvComprasData.Contains(compraData))
                    {
                        CompraTemp.DtgvComprasData.Add(compraData);
                    }
                }
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
                // Obtén la oferta del producto actualizado 
                Oferta oferta = producto.oOferta;

                // Mostrar el tipo de oferta en un Label o TextBox
                lblOferta.Text = oferta.NombreOferta;

                // Calcular el precio con descuento directamente
                decimal precioOriginal = productoActual.PrecioCompra; // Precio original del producto
                decimal descuento = oferta.Descuento; // Descuento de la oferta (ajusta esto según tus datos reales)

                decimal precioConDescuento = precioOriginal - (precioOriginal * descuento / 100);

                // Mostrar el precio con descuento en un Label o TextBox
                lblpreciodescuento.Text = precioConDescuento.ToString("C"); // Muestra el precio con formato de moneda
            }
            else
            {
                // No se encontró una oferta válida para este producto, puedes manejarlo apropiadamente
                lblOferta.Text = ""; // Muestra un mensaje que indique que no hay oferta
                lblpreciodescuento.Text = productoActual.PrecioCompra.ToString("C"); // Muestra el precio original
            }
        }

        private void lblTextprecio_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            CompraTemp.DtgvComprasVisible = true;
            dtgvCompra.Visible = true;
            string precioCompra = txtPrecio.Text; // Obtener el precio de compra del control correspondiente

            string cantidad = lblcantidad.Text; // Obtener la cantidad del control correspondiente
            if (lblpreciodescuento.Text != "")
            {
                precioCompra = lblpreciodescuento.Text;
            }
            string producto = txtNombre.Text; // Obtener el nombre del producto del control correspondiente
            string oferta = lblOferta.Text;

            dtgvCompra.Rows.Add(cantidad, producto, precioCompra, oferta);
            string compraData = $"{cantidad},{producto},{precioCompra},{oferta}";
            CompraTemp.DtgvComprasData.Add(compraData);

        }

        private void FrmVistaDetalleProducto_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dtgvCompra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dtgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPedirStock_Click(object sender, EventArgs e)
        {
            RegistrarEscaneoEnBaseDeDatos(productoActual.IdProducto);

        }
    }
}
