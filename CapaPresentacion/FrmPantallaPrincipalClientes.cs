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

namespace CapaPresentacion
{
    public partial class FrmPantallaPrincipalClientes : Form
    {
        private ActivityTimer activityTimer;

        private Timer videoTimer;
        private const int MarginOfError = 1;


        private List<Oferta> ofertas;
        private List<byte[]> fotosOfertas;
        private int ofertaActualIndex;
        public FrmPantallaPrincipalClientes()
        {
            InitializeComponent();
        }
        private void VideoTimer_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    // Verificar si el reproductor está reproduciendo y si el objeto currentMedia no es null
            //    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying &&
            //        axWindowsMediaPlayer1.currentMedia != null &&
            //        axWindowsMediaPlayer1.Ctlcontrols.currentPosition > axWindowsMediaPlayer1.currentMedia.duration - MarginOfError)
            //    {
            //        // Reiniciar la reproducción del video desde el principio
            //        axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0;
            //        axWindowsMediaPlayer1.Ctlcontrols.play();
            //    }
            //}
            //catch (System.Runtime.InteropServices.InvalidComObjectException ex)
            //{
            //    // Manejar la excepción aquí (puedes registrarla o mostrar un mensaje de error)
            //    // Por ejemplo:
            //    Console.WriteLine("Excepción de objeto COM no válido: " + ex.Message);
            //}
        }
        
        private void FrmPantallaPrincipalClientes_Load(object sender, EventArgs e)
        {
            //string mp4FilePath = @"C:\Users\Luciano\OneDrive\Escritorio\videoreferencia.mp4";
            //axWindowsMediaPlayer1.URL = mp4FilePath;
            //axWindowsMediaPlayer1.uiMode = "none"; // Ocultar la interfaz del reproductor

            //// Suscribir al evento PlayStateChange para detectar cambios de estado
            //axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange_1;
            //axWindowsMediaPlayer1.OpenStateChange += axWindowsMediaPlayer1_OpenStateChange;
            //videoTimer = new Timer();
            //videoTimer.Interval = 100; // Verificar cada 100 milisegundos
            //videoTimer.Tick += VideoTimer_Tick;
            //videoTimer.Start();


            bool obtenido = true;
            byte[] byteimagen = new CN_Negocio().ObtenerFoto(out obtenido);

            if (obtenido)
            {
                picNegocio.Image = ByteAImagen(byteimagen);
            }
            Negocio datos = new CN_Negocio().ObtenerDatos();

            lblNegocio.Text = datos.Nombre;

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

            timerCarrusel.Interval = 7000;
            timerCarrusel.Tick += timerCarrusel_Tick;
            timerCarrusel.Start();
        }
        public Image ByteAImagen(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            Image imagen = Image.FromStream(ms);
            return imagen;
        }
        private void MostrarOfertaActual()
        {
            if (fotosOfertas.Count > 0 && ofertaActualIndex >= 0 && ofertaActualIndex < fotosOfertas.Count)
            {
                Image imagenOferta = ByteAImagen(fotosOfertas[ofertaActualIndex]);
                picOfertas.Image = imagenOferta;
                picOfertas.Refresh();

            }
            else
            {
                picOfertas.Refresh();
            }
        }
        private void timerCarrusel_Tick(object sender, EventArgs e)
        {
            // Incrementar el índice de la oferta actual
            ofertaActualIndex++;

            // Verificar si el índice supera el número de ofertas disponibles
            if (ofertaActualIndex >= fotosOfertas.Count)
            {
                // Si es así, volver al inicio del carrusel
                ofertaActualIndex = 0;
            }

            // Mostrar la oferta actual
            MostrarOfertaActual();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picOfertas_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();

            this.Close();


            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }



        private void FrmPantallaPrincipalClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Detener y liberar el temporizador de carrusel al cerrar el formulario
            timerCarrusel.Stop();
            timerCarrusel.Dispose();
            this.Dispose();

            this.Close();

        }

        private void picOfertas_Click_2(object sender, EventArgs e)
        {
            this.Dispose();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
