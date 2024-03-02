using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLegales : Form
    {
        public FrmLegales()
        {
            InitializeComponent();

        }

        public Image ByteAImagen(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void FrmLegales_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimagen = new CN_Negocio().ObtenerFoto(out obtenido);

            if (obtenido)
            {
                picFoto.Image = ByteAImagen(byteimagen);
            }

            Negocio datos = new CN_Negocio().ObtenerDatos();

            txtNombre.Text = datos.Nombre;
            txtCuit.Text = datos.CUIT;
            txtDireccion.Text = datos.Direccion;
            txtCodigoSeguridad.Text = datos.CodigoSeguridad;


        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico;*.tif;*.tiff;*.emf;*.wmf;*.svg;*.exif;*.jfif;*.jpe;*.jif;*.webp;*.webp2;*.webp3";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Genera un nombre de archivo único basado en la fecha y la hora
                    string fileName = "temp_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                    // Carga la imagen WebP y la guarda con el nombre único
                    using (MagickImage webpImage = new MagickImage(openFileDialog.FileName))
                    {
                        webpImage.Format = MagickFormat.Jpeg;
                        webpImage.Write(fileName);
                    }

                    picFoto.Image = Image.FromFile(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio datos = new Negocio
                {
                    Nombre = txtNombre.Text,
                    CUIT = txtCuit.Text,
                    Direccion = txtDireccion.Text,
                    CodigoSeguridad = txtCodigoSeguridad.Text

                };

                string mensaje;
                bool respuesta = new CN_Negocio().Guardar(datos, out mensaje);

                if (respuesta)
                {

                }
                else
                {
                    MessageBox.Show($"Error al guardar los datos: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                byte[] byteimagen = null;
                string mensaje = string.Empty;


                if (picFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picFoto.Image.Save(ms, ImageFormat.Jpeg);
                        byteimagen = ms.ToArray();
                    }
                }

                bool respuesta = new CN_Negocio().ActualizarFoto(byteimagen, out mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
