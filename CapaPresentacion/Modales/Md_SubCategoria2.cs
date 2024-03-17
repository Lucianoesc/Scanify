using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ImageMagick;
using MaterialSkin;
using MaterialSkin.Controls;
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

namespace CapaPresentacion.Modales
{
    public partial class Md_SubCategoria2 : MaterialForm
    {
        public delegate void ActualizadorEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ActualizadorEventHandler SubCategoria2Actualizada;
        public int IdSubCategoriaSeleccionada { get; private set; }
        MaterialSkinManager materialSkinManager;

        public Md_SubCategoria2(int idsubcategoria = 0, int idsubcategoria2 = 0)
        {
            InitializeComponent();
            IdSubCategoriaSeleccionada = idsubcategoria;
            txtId.Text = idsubcategoria2.ToString();


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
        private void Md_SubCategoria2_Load(object sender, EventArgs e)
        {
            cmbSubCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

            List<SubCategoria> listaSubCategoria = new CN_SubCategoria().Listar();

            foreach (SubCategoria item in listaSubCategoria)
            {
                cmbSubCategoria.Items.Add(new OpcionCombo() { Valor = item.IdSubCategoria, Texto = item.Descripcion });
            }

            cmbSubCategoria.DisplayMember = "Texto";
            cmbSubCategoria.ValueMember = "Valor";

            // Seleccionar la categoría correspondiente a IdCategoriaSeleccionada
            foreach (OpcionCombo item in cmbSubCategoria.Items)
            {
                if (Convert.ToInt32(item.Valor) == IdSubCategoriaSeleccionada)
                {
                    cmbSubCategoria.SelectedItem = item;
                    break;
                }
            }

            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;

        }
        public void CargarDatosProducto(int idsubcategoria2, string titulo, string estado)
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
            byte[] bytesImagen = new CN_SubCategoria2().ObtenerFotoSubCategoria2(idsubcategoria2, out obtenido);

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
                SubCategoria2 objsubcategoria2 = new SubCategoria2()
                {
                    IdSubCategoria2 = Convert.ToInt32(txtId.Text),
                    Descripcion = txtNombre.Text,
                    oSubCategoria = new SubCategoria() { IdSubCategoria = Convert.ToInt32(((OpcionCombo)cmbSubCategoria.SelectedItem).Valor) },
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

                CN_SubCategoria2 cnSubCategoria2 = new CN_SubCategoria2();


                if (objsubcategoria2.IdSubCategoria2 == 0)
                {
                    int idsubcategoria2generado = cnSubCategoria2.Registrar(objsubcategoria2, byteimagen, out mensaje);

                    if (idsubcategoria2generado != 0)
                    {
                        SubCategoria2Actualizada?.Invoke(this, e);

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
                    bool resultado = cnSubCategoria2.Editar(objsubcategoria2, byteimagen, out mensaje);

                    if (resultado)
                    {
                        SubCategoria2Actualizada?.Invoke(this, e);

                        limpiar();
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
            cmbSubCategoria.SelectedIndex = 0;

            cmbEstado.SelectedIndex = 0;
            txtNombre.Focus();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void picFoto_MouseClick(object sender, MouseEventArgs e)
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

        private void picFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
