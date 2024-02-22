using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using CapaEntidad;
using CapaNegocio;
using System.Linq;
using Irony.Parsing;
using System.Collections.Generic;
using CapaPresentacion.Modales;
using System.Resources;

namespace CapaPresentacion
{
    public partial class FrmScanear : Form
    {

        private FrmVistaDetalleProducto detalleproducto;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private BarcodeReader reader;
        private bool isCameraStarted;
        private BarcodeReader barcodeReader;
        public FrmScanear()
        {
            InitializeComponent();
            reader = new BarcodeReader();
            isCameraStarted = false;
            CambiarIdioma(IdiomaConfig.Idioma); // Cambiar el idioma al cargar el formulario




        }
        private void CambiarIdioma(string idioma)
        {
            ResourceManager resources = new ResourceManager($"Recursos_{idioma}", typeof(FrmVistaDetalleProducto).Assembly);

            lblScanear.Text = Rec.Scanea_el_Código_de_barras;
        }
        private void IniciarCamara()
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
                isCameraStarted = true;
                barcodeReader = new BarcodeReader();

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

            // Configurar el lector de códigos de barras para admitir varios formatos que podremos usar a futuro
            reader = new BarcodeReader
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.EAN_8,
                BarcodeFormat.EAN_13,
                BarcodeFormat.UPC_A,
                BarcodeFormat.UPC_E,
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_39,
            },
                },
            };

            IniciarCamara();

        }
        
        private void FrmScanear_Load(object sender, EventArgs e)
        {
            InicializarCamara();
        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Actualizar el PictureBox con el nuevo fotograma de la cámara
            pictureBoxCamera.Image = (System.Drawing.Image)eventArgs.Frame.Clone();

            // Decodificar el código de barras utilizando ZBar
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            Result result = barcodeReader.Decode(frame);

            if (result != null)
            {
                txtCodigoBarras.Invoke((MethodInvoker)delegate
                {
                    txtCodigoBarras.Text = result.Text;
                });
            }
        }

        private void FrmScanear_FormClosing(object sender, FormClosingEventArgs e)
        {
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                isCameraStarted = false;
            }

            this.Hide();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
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
                detalleproducto = new FrmVistaDetalleProducto(codbarras);
                detalleproducto.PreviousForm = this;
                detalleproducto.Show();
                RegistrarEscaneoEnBaseDeDatos(codbarras.IdProducto);
                this.Hide();
                txtCodigoBarras.Text = "";

            }
        }
        private void RegistrarEscaneoEnBaseDeDatos(int productoId)
        {
            CN_Consulta cnConsultas = new CN_Consulta();

            Consulta escaneo = new Consulta
            {
                IdProducto = productoId,
                FechaEscaneo = DateTime.Now
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



        private void FrmScanear_Activated_1(object sender, EventArgs e)
        {
            if (!isCameraStarted)
            {
                InicializarCamara();
            }
        }

        private void pictureBoxCamera_MouseEnter(object sender, EventArgs e)
        {
           
        }
    }
}
