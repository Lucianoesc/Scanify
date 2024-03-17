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
    public partial class Md_SubCategoria : MaterialForm
    {

        public delegate void ActualizadorEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ActualizadorEventHandler SubCategoriaActualizada;
        public int IdCategoriaSeleccionada { get; private set; }



        MaterialSkinManager materialSkinManager;
        public Md_SubCategoria(int idcategoria = 0,int idsubcategoria = 0)
        {
            InitializeComponent();

            IdCategoriaSeleccionada = idcategoria;
            txtId.Text = idsubcategoria.ToString();


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
        private void Md_SubCategoria_Load(object sender, EventArgs e)
        {
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                cmbCategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }

            cmbCategoria.DisplayMember = "Texto";
            cmbCategoria.ValueMember = "Valor";

            foreach (OpcionCombo item in cmbCategoria.Items)
            {
                if (Convert.ToInt32(item.Valor) == IdCategoriaSeleccionada)
                {
                    cmbCategoria.SelectedItem = item;
                    break;
                }
            }

            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;
        }

        public void CargarDatosProducto(int idsubcategoria, string titulo, string estado)
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
            byte[] bytesImagen = new CN_SubCategoria().ObtenerFotoSubCategoria(idsubcategoria, out obtenido);

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
                SubCategoria objsubcategoria = new SubCategoria()
                {
                    IdSubCategoria = Convert.ToInt32(txtId.Text),
                    Descripcion = txtNombre.Text,
                    oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cmbCategoria.SelectedItem).Valor) },
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

                CN_SubCategoria cnSubCategoria = new CN_SubCategoria();


                if (objsubcategoria.IdSubCategoria == 0)
                {
                    int idcategoriagenerado = cnSubCategoria.Registrar(objsubcategoria, byteimagen, out mensaje);

                    if (idcategoriagenerado != 0)
                    {
                        SubCategoriaActualizada?.Invoke(this, e);

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
                    bool resultado = cnSubCategoria.Editar(objsubcategoria, byteimagen, out mensaje);

                    if (resultado)
                    {
                        SubCategoriaActualizada?.Invoke(this, e);

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
            cmbCategoria.SelectedIndex = 0;

            cmbEstado.SelectedIndex = 0;
            txtNombre.Focus();
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
       
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
