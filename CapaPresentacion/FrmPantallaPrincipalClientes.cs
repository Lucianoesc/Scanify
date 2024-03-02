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
        private List<Oferta> ofertas;
        private List<byte[]> fotosOfertas;
        private int ofertaActualIndex;
        public FrmPantallaPrincipalClientes()
        {
            InitializeComponent();
        }

        private void FrmPantallaPrincipalClientes_Load(object sender, EventArgs e)
        {
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

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }

        private void picOfertas_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneTextBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }

        private void picOfertas_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            FrmInicioClientes frm = new FrmInicioClientes();
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
