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
    public partial class FrmNegocio : Form
    {
        private static Usuario usuarioActual;

        public FrmNegocio(Usuario objUsuario)
        {
            InitializeComponent();
            usuarioActual = objUsuario;

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
                    string filePath = openFileDialog.FileName;

                    using (MagickImage image = new MagickImage(filePath))
                    {
                        image.Format = MagickFormat.Png;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Write(ms);

                            picFoto.Image = Image.FromStream(ms);
                        }
                    }
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
                string username = usuarioActual.Username;
                Usuario usuario = new CN_Usuario().Listar().FirstOrDefault(u => u.Username == username);

                CN_Bitacora cnBitacora = new CN_Bitacora(); // Mover la declaración aquí

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
                    MessageBox.Show("Datos del negocio cambiados con exito!", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cnBitacora.InsertarBitacora(usuario.Username, usuario.IdUsuario.ToString(), "Datos del negocio cambiados", "Cambio exitoso", "FrmNegocio");

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

        private void picFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
