using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmInicioClientes : Form
    {
        bool IdiomaExpandido;
        private List<Oferta> ofertas; // Lista de ofertas
        private List<byte[]> fotosOfertas; // Lista de fotos de ofertas
        private int ofertaActualIndex; // Índice de la oferta actual
        private string idiomaSeleccionado; // Variable para almacenar el idioma seleccionado
        public FrmInicioClientes()
        {
            InitializeComponent();
            fotosOfertas = new List<byte[]>();
            ofertaActualIndex = 0;
            // Inicializar el idioma seleccionado con el idioma predeterminado
            idiomaSeleccionado = "es";
            CambiarIdioma(idiomaSeleccionado);
        }
        
        public Image ByteAImagen(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmScanear frm = new FrmScanear();
            frm.Show();
        }

        private void FrmInicioClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cerrar todos los formularios y finalizar la aplicación
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmBusquedaCategoria frm = new FrmBusquedaCategoria();
            frm.Show();
        }

        private void FrmInicioClientes_Load(object sender, EventArgs e)
        {

            
            InactivityTimerManager.InactivityDetected += ShowMyMessageBox;
            InactivityTimerManager.Start();

            // Obtén todas las ofertas con sus fotos
            ofertas = new CN_Oferta().Listar(); // Inicializa la lista de ofertas

            foreach (Oferta oferta in ofertas)
            {
                if (oferta.Foto != null && oferta.Foto.Length > 0)
                {
                    fotosOfertas.Add(oferta.Foto);
                }
            }

            if (fotosOfertas.Count > 0)
            {
                MostrarOfertaActual();
            }


        }
        private void AnyActivityEventHandler(object sender, EventArgs e)
        {
            InactivityTimerManager.StopAllTimers();
            InactivityTimerManager.Start();
        }
        private void ShowMyMessageBox()
        {

        }
        private void MostrarOfertaActual()
        {
            if (fotosOfertas.Count > 0 && ofertaActualIndex >= 0 && ofertaActualIndex < fotosOfertas.Count)
            {
                Image imagenOferta = ByteAImagen(fotosOfertas[ofertaActualIndex]);
                picOfertas.Image = imagenOferta;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (ofertaActualIndex < fotosOfertas.Count - 1)
            {
                ofertaActualIndex++;
                MostrarOfertaActual();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (ofertaActualIndex > 0)
            {
                ofertaActualIndex--;
                MostrarOfertaActual();
            }
        }

        private void picOfertas_Click(object sender, EventArgs e)
        {

            if (ofertaActualIndex >= 0 && ofertaActualIndex < fotosOfertas.Count)
            {
                // Obtén el ID de oferta actual
                int idOfertaSeleccionada = 0;
                if (ofertaActualIndex < ofertas.Count)
                {
                    idOfertaSeleccionada = ofertas[ofertaActualIndex].IdOferta;
                }

                FrmBusquedaCategoria frm = new FrmBusquedaCategoria();
                frm.IdOferta = idOfertaSeleccionada; // Establece el IdOferta en FrmBusquedaCategoria
                frm.Show();
                this.Hide();
            }
        }





       
        private void FrmInicioClientes_Activated(object sender, EventArgs e)
        {

        }

        private void picOfertas_MouseEnter(object sender, EventArgs e)
        {


        }

        private void FrmInicioClientes_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmInicioClientes_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            CompraTemp.ReiniciarCompraTemp(); // Reiniciar la compra temporal aquí

        }

        private void IdiomaTimer_Tick(object sender, EventArgs e)
        {
            if (IdiomaExpandido)
            {
                panelIdiomas.Height += 10;
                if (panelIdiomas.Height == panelIdiomas.MaximumSize.Height)
                {
                    IdiomaExpandido = false;
                    IdiomaTimer.Stop();
                }
            }
            else
            {
                panelIdiomas.Height -= 10;
                if(panelIdiomas.Height== panelIdiomas.MinimumSize.Height)
                {
                    IdiomaExpandido = true;
                    IdiomaTimer.Stop();
                }
            }

        }
        private void CambiarIdioma(string idioma)
        {
            // Guardar el idioma seleccionado
            idiomaSeleccionado = idioma;

            // Obtener el nombre del archivo de recursos según el idioma seleccionado
            string nombreArchivoRecursos = idioma == "en-US" ? "Rec.en-US.resx" : "Rec.resx";

            // Inicializar ResourceManager con el archivo de recursos correspondiente
            ResourceManager resources = new ResourceManager(nombreArchivoRecursos, typeof(FrmInicioClientes).Assembly);

            // Obtener textos de recursos de idioma según la cultura actual del hilo
            lblBuscarPorCat.Text = Rec.Buscar_un_producto_en_categorias;
            lblScanear.Text = Rec.Scanear_un_producto;
            btnIdioma.Text = Rec.Idioma;
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            IdiomaTimer.Start();
        }
        
        private void btnIngles_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("en-US");
            CambiarIdioma("en-US");
            IdiomaConfig.Idioma = "en-US"; // Actualizar el idioma seleccionado

        }

        private void btnEspañol_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("");
            CambiarIdioma("es");
            IdiomaConfig.Idioma = "es"; // Actualizar el idioma seleccionado

        }
    }
}
