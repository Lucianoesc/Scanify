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
    public partial class FrmPrincipal : Form
    {
        private List<Oferta> ofertas;
        private List<byte[]> fotosOfertas;
        private int ofertaActualIndex;
        public FrmPrincipal()
        {

            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
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

        private void timerCarrusel_Tick(object sender, EventArgs e)
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

        public Image ByteAImagen(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            Image imagen = Image.FromStream(ms);
            return imagen;
        }

        private void FrmPrincipal_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }

        private void picOfertas_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }
    }
}
