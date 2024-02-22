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
using iTextSharp.text.pdf.codec.wmf;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CapaPresentacion.Modales
{
    public partial class ModalControladorProductos : MaterialForm
    {
        // Delegado para definir el tipo de evento
        public delegate void ProductosActualizadosEventHandler(object sender, EventArgs e);

        // Evento que se disparará cuando se actualicen los productos
        public event ProductosActualizadosEventHandler ProductosActualizados;

        // Método para invocar el evento
        protected virtual void OnProductosActualizados(EventArgs e)
        {
            ProductosActualizados?.Invoke(this, e);
        }

        MaterialSkinManager materialSkinManager;
        
        public ModalControladorProductos(int idProducto = 0)
        {
            InitializeComponent();
            txtId.Text = idProducto.ToString();


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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] byteimagen = null;
                string mensaje = string.Empty;
                Producto objproducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Codigo = txtCodigo.Text,
                    oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cmbCategoria.SelectedItem).Valor) },
                    InformacionNutricional = txtInfoNutricional.Text,
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

                CN_Producto cnProducto = new CN_Producto();


                if (objproducto.IdProducto == 0)
                {
                    int idproductogenerado = cnProducto.Registrar(objproducto, byteimagen, out mensaje);

                    if (idproductogenerado != 0)
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
                    bool resultado = cnProducto.Editar(objproducto, byteimagen, out mensaje);

                    if (resultado)
                    {
                        // Notificar a FrmProductos que los productos han sido actualizados
                        limpiar();

                        MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtDescripcion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtInfoNutricional.Text = string.Empty;
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
        public void CargarDatosProducto(int idProducto, string titulo, string descripcion, string codigo, string categoria, string stock, string precioCompra, string precioVenta, string estado)
        {
            // Establecer los valores de los controles de edición con los datos del producto
            txtNombre.Text = titulo;
            txtDescripcion.Text = descripcion;
            txtCodigo.Text = codigo;
            txtStock.Text = stock;
            txtPrecioCompra.Text = precioCompra;
            txtPrecioVenta.Text = precioVenta;
            foreach (OpcionCombo item in cmbCategoria.Items)
            {
                if (item.Texto == categoria)
                {
                    cmbCategoria.SelectedItem = item;
                    break;
                }
            }

            // Establecer la selección del ComboBox de estado
            foreach (OpcionCombo item in cmbEstado.Items)
            {
                if (item.Texto == estado)
                {
                    cmbEstado.SelectedItem = item;
                    break;
                }
            }
            bool obtenido = true;
            byte[] bytesImagen = new CN_Producto().ObtenerFoto(idProducto, out obtenido);

            if (obtenido)
            {
                Image imagen = ByteAimagen(bytesImagen);
                picFoto.Image = imagen;

            }
        }
        private void ModalControladorProductos_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;

            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                cmbCategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cmbCategoria.DisplayMember = "Texto";
            cmbCategoria.ValueMember = "Value";
            cmbCategoria.SelectedIndex = 0;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
