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
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ImageMagick;
using MaterialSkin;
using MaterialSkin.Controls;
using static CapaPresentacion.CategoriaControl;

namespace CapaPresentacion.Modales
{
    public partial class Md_Categoria : MaterialForm
    {
        MaterialSkinManager materialSkinManager;
        public delegate void ActualizadorEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ActualizadorEventHandler Actualizador;

        // Método para invocar el evento
        protected virtual void OnProductosActualizados(EventArgs e)
        {
            Actualizador?.Invoke(this, e);
        }
        public Md_Categoria(int idCategoria = 0)
        {
            InitializeComponent();
            txtId.Text = idCategoria.ToString();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey900, Accent.Cyan700, TextShade.WHITE);
        }

        public Image ByteAimagen(byte[] imagenBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes, 0, imagenBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        }
        public void CargarDatosProducto(int idCategoria, string titulo, string estado)
        {
            txtNombre.Text = titulo;

            foreach (OpcionCombo item in cmbEstado.Items)
            {
                if (item.Texto == estado)
                {
                    cmbEstado.SelectedItem = item;
                    break;
                }
            }
            bool obtenido = true;
            byte[] bytesImagen = new CN_Categoria().ObtenerFotoCategoria(idCategoria, out obtenido);

            if (obtenido)
            {
                Image imagen = ByteAimagen(bytesImagen);
                picFoto.Image = imagen;

            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] byteimagen = null;
                string mensaje = string.Empty;
                Categoria objcategoria = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(txtId.Text),
                    Descripcion = txtNombre.Text,
                    Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1
                };

                if (picFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picFoto.Image.Save(ms, ImageFormat.Jpeg);
                        byteimagen = ms.ToArray();
                    }
                }

                CN_Categoria cnCategoria = new CN_Categoria();


                if (objcategoria.IdCategoria == 0)
                {
                    int idcategoriagenerado = cnCategoria.Registrar(objcategoria, byteimagen, out mensaje);

                    if (idcategoriagenerado != 0)
                    {
                        // Notificar a FrmProductos que los productos han sido actualizados
                        OnProductosActualizados(EventArgs.Empty);
                        limpiar();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool resultado = cnCategoria.Editar(objcategoria, byteimagen, out mensaje);

                    if (resultado)
                    {
                        OnProductosActualizados(EventArgs.Empty);
                        limpiar();

                        MessageBox.Show("Categoria actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtNombre.Text = string.Empty;
            picFoto.Image = Properties.Resources.fotonodata;
            cmbEstado.SelectedIndex = 0;
            txtNombre.Focus();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void picFoto_Click(object sender, EventArgs e)
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

        private void Md_Categoria_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
