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
        private ActivityTimer activityTimer;

        bool IdiomaExpandido;
        private List<Oferta> ofertas; // Lista de ofertas
        private List<byte[]> fotosOfertas; // Lista de fotos de ofertas
        private int ofertaActualIndex; // Índice de la oferta actual
        private string idiomaSeleccionado;

        public FrmInicioClientes()
        {
            InitializeComponent();
            fotosOfertas = new List<byte[]>();
            ofertaActualIndex = 0;
            // Inicializar el idioma seleccionado con el idioma predeterminado
            idiomaSeleccionado = "es";
            CambiarIdioma(idiomaSeleccionado);
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
                activityTimer.Stop();
                this.Dispose();

                this.Close();
            }
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
            activityTimer.Stop();
            FrmScanear frm = new FrmScanear();
            frm.Show();
            this.Close();
            this.Dispose();

        }

        private void FrmInicioClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            activityTimer.Stop();
            this.Dispose();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            
            FrmBusquedaCategoria frm = new FrmBusquedaCategoria();
            frm.Show();
            this.Dispose();
            this.Close();

        }
        
        private void FrmInicioClientes_Load(object sender, EventArgs e)
        {



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
            activityTimer.Stop();
            activityTimer.Start();
            if (ofertaActualIndex < fotosOfertas.Count - 1)
            {
                ofertaActualIndex++;
                MostrarOfertaActual();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            if (ofertaActualIndex > 0)
            {
                ofertaActualIndex--;
                MostrarOfertaActual();
            }
        }

        private void picOfertas_Click(object sender, EventArgs e)
        {

            if (ofertaActualIndex >= 0 && ofertaActualIndex < ofertas.Count)
            {
                // Obtén el ID de la oferta actual
                int idOfertaSeleccionada = ofertas[ofertaActualIndex].IdOferta;

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
            this.Dispose();
            this.Close();

            activityTimer.Stop();

        }

        private void FrmInicioClientes_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            CompraTemp.ReiniciarCompraTemp(); // Reiniciar la compra temporal aquí
            FrmPantallaPrincipalClientes frm = new FrmPantallaPrincipalClientes();
            frm.Show();
            this.Dispose();
            this.Close();

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
            activityTimer.Stop();
            activityTimer.Start();
            IdiomaTimer.Start();
        }
        
        private void btnIngles_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("en-US");
            CambiarIdioma("en-US");
            IdiomaConfig.Idioma = "en-US"; // Actualizar el idioma seleccionado

        }

        private void btnEspañol_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("");
            CambiarIdioma("es");
            IdiomaConfig.Idioma = "es"; // Actualizar el idioma seleccionado

        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnSeguridad_Click_1(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            Md_CodigoSeguro frm = new Md_CodigoSeguro();
            frm.ShowDialog();
        }

        private void FrmInicioClientes_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
        }
    }
}
