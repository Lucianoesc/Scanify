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
using AForge.Video;
using AForge.Video.DirectShow;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ImageMagick;
using iTextSharp.text.pdf.codec.wmf;
using MaterialSkin;
using MaterialSkin.Controls;
using ZXing;

namespace CapaPresentacion.Modales
{
    public partial class ModalControladorProductos : MaterialForm
    {

        public int IdCategoriaSeleccionada { get; private set; }
        public int IdSubCategoriaSeleccionada { get; private set; }
        public int IdSubCategoria2Seleccionada { get; private set; }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private BarcodeReader reader;
        private bool isCameraStarted;
        private BarcodeReader barcodeReader;
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
        
        public ModalControladorProductos(int idcategoria = 0 , int idsubcategoria = 0, int idsubcategoria2 = 0,int idProducto = 0)
        {


            InitializeComponent();


            IdCategoriaSeleccionada = idcategoria;
            IdSubCategoriaSeleccionada = idsubcategoria;
            IdSubCategoria2Seleccionada = idsubcategoria2;


            txtId.Text = idProducto.ToString();
            reader = new BarcodeReader();
            isCameraStarted = false;


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
        private void IniciarCamara()
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
                isCameraStarted = true;
                barcodeReader = new BarcodeReader();

            }
        }
        private void InicializarCamara()
        {
            // Enumerar dispositivos de video disponibles
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No se encontraron dispositivos de video.");
                return;
            }

            // Inicializar la cámara con el primer dispositivo disponible si no está instanciada
            if (videoSource == null)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            }

            // Configurar el lector de códigos de barras para admitir varios formatos que podremos usar a futuro
            reader = new BarcodeReader
            {
                Options = new ZXing.Common.DecodingOptions
                {
                    PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.EAN_8,
                BarcodeFormat.EAN_13,
                BarcodeFormat.UPC_A,
                BarcodeFormat.UPC_E,
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_39,
            },
                },
            };

            IniciarCamara();

        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Actualizar el PictureBox con el nuevo fotograma de la cámara
            pictureBoxCamera.Image = (System.Drawing.Image)eventArgs.Frame.Clone();

            // Decodificar el código de barras utilizando ZBar
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            Result result = barcodeReader.Decode(frame);

            if (result != null)
            {
                txtCodigo.Invoke((MethodInvoker)delegate
                {
                    txtCodigo.Text = result.Text;
                });
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] byteimagen = null;
                string mensaje = string.Empty;

                int stock = Convert.ToInt32(txtStock.Text);
                decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);

                Producto objproducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Codigo = txtCodigo.Text,
                    oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cmbCategoria.SelectedItem).Valor) },
                    oSubCategoria = new SubCategoria() { IdSubCategoria = Convert.ToInt32(((OpcionCombo)cmbSubCategoria.SelectedItem).Valor) },
                    oSubCategoria2 = new SubCategoria2() { IdSubCategoria2 = Convert.ToInt32(((OpcionCombo)cmbSubCategoria2.SelectedItem).Valor) },
                    InformacionNutricional = txtInfoNutricional.Text,
                    Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1,
                    Stock = stock,
                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    StockLimite = Convert.ToInt32(txtStockLimite.Text) 
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
                        OnProductosActualizados(EventArgs.Empty);
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
            // Deshabilitar los eventos de cambio de selección
            cmbCategoria.SelectedIndexChanged -= cmbCategoria_SelectedIndexChanged;
            cmbSubCategoria.SelectedIndexChanged -= cmbSubCategoria_SelectedIndexChanged;

            // Limpiar los ComboBox
            cmbCategoria.SelectedIndex = -1;
            cmbSubCategoria.Items.Clear();
            cmbSubCategoria.SelectedIndex = -1;
            cmbSubCategoria2.Items.Clear();
            cmbSubCategoria2.SelectedIndex = -1;

            // Volver a habilitar los eventos de cambio de selección
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            cmbSubCategoria.SelectedIndexChanged += cmbSubCategoria_SelectedIndexChanged;

            // Resto del código de limpieza
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtNombre.Text = string.Empty;
            picFoto.Image = Properties.Resources.sin_imagen__1_;
            txtDescripcion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtInfoNutricional.Text = string.Empty;
            cmbEstado.SelectedIndex = 0;
            txtPrecioCompra.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtStockMinimo.Text = string.Empty;
            txtStockLimite.Text = string.Empty;
            txtStock.Text = string.Empty;
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
        
        private void ModalControladorProductos_Load(object sender, EventArgs e)
        {
            List<Categoria> listaCategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listaCategoria)
            {
                cmbCategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cmbCategoria.DisplayMember = "Texto";
            cmbCategoria.ValueMember = "Valor";

            // Si se está editando un producto, seleccionar la categoría correspondiente
            if (IdCategoriaSeleccionada != 0)
            {
                foreach (OpcionCombo item in cmbCategoria.Items)
                {
                    if (Convert.ToInt32(item.Valor) == IdCategoriaSeleccionada)
                    {
                        cmbCategoria.SelectedItem = item;
                        break;
                    }
                }
            }
            List<SubCategoria> listaSubCategoria = new CN_SubCategoria().Listar();
            foreach (SubCategoria item in listaSubCategoria)
            {
                cmbSubCategoria.Items.Add(new OpcionCombo() { Valor = item.IdSubCategoria, Texto = item.Descripcion });
            }
            cmbSubCategoria.DisplayMember = "Texto";
            cmbSubCategoria.ValueMember = "Valor";

            // Si se está editando un producto, seleccionar la categoría correspondiente
            if (IdSubCategoriaSeleccionada != 0)
            {
                foreach (OpcionCombo item in cmbSubCategoria.Items)
                {
                    if (Convert.ToInt32(item.Valor) == IdSubCategoriaSeleccionada)
                    {
                        cmbSubCategoria.SelectedItem = item;
                        break;
                    }
                }
            }

            List<SubCategoria2> listaSubCategoria2 = new CN_SubCategoria2().Listar();
            foreach (SubCategoria2 item in listaSubCategoria2)
            {
                cmbSubCategoria2.Items.Add(new OpcionCombo() { Valor = item.IdSubCategoria2, Texto = item.Descripcion });
            }
            cmbSubCategoria2.DisplayMember = "Texto";
            cmbSubCategoria2.ValueMember = "Valor";

            // Si se está editando un producto, seleccionar la categoría correspondiente
            if (IdSubCategoria2Seleccionada != 0)
            {
                foreach (OpcionCombo item in cmbSubCategoria2.Items)
                {
                    if (Convert.ToInt32(item.Valor) == IdSubCategoria2Seleccionada)
                    {
                        cmbSubCategoria2.SelectedItem = item;
                        break;
                    }
                }
            }
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }
        
        private void ModalControladorProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                isCameraStarted = false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            

            
        }

        private void ModalControladorProductos_Activated(object sender, EventArgs e)
        {
            if (!isCameraStarted)
            {
                InicializarCamara();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!isCameraStarted)
            {
                pictureBoxCamera.Visible = true;

                InicializarCamara();
            }
            else if (videoSource != null && videoSource.IsRunning)
            {
                pictureBoxCamera.Visible= false;
                videoSource.SignalToStop();
                isCameraStarted = false;
            }
            


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem != null)
            {
                cmbSubCategoria.Items.Clear();
                cmbSubCategoria.SelectedIndex = -1;                

                // Si se está editando un producto y la subcategoría 2 ya está seleccionada, seleccionarla
                if (IdSubCategoriaSeleccionada != 0)
                {
                    foreach (OpcionCombo item in cmbSubCategoria.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == IdSubCategoriaSeleccionada)
                        {
                            cmbSubCategoria.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void cmbSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubCategoria.SelectedItem != null)
            {
                cmbSubCategoria2.Items.Clear();
                cmbSubCategoria2.SelectedIndex = -1;

                int idSubCategoriaSeleccionada = Convert.ToInt32(((OpcionCombo)cmbSubCategoria.SelectedItem).Valor);

                List<SubCategoria2> listaSubCategoria2 = new CN_SubCategoria2().ListarPorIdSubCategoria(idSubCategoriaSeleccionada);

                foreach (SubCategoria2 item in listaSubCategoria2)
                {
                    cmbSubCategoria2.Items.Add(new OpcionCombo() { Valor = item.IdSubCategoria2, Texto = item.Descripcion });
                }

                // Si se está editando un producto y la subcategoría 2 ya está seleccionada, seleccionarla
                if (IdSubCategoria2Seleccionada != 0)
                {
                    foreach (OpcionCombo item in cmbSubCategoria2.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == IdSubCategoria2Seleccionada)
                        {
                            cmbSubCategoria2.SelectedItem = item;
                            break;
                        }
                    }
                }
            }

        }

        public void CargarDatosProducto(int idProducto, string titulo, string descripcion, string codigo, int categoria, int subcategoria, int subcategoria2,
                                string stock, string precioCompra, string precioVenta, string estado, string infonutricional, string stockminimo, string stocklimite)
        {
            txtNombre.Text = titulo;
            txtDescripcion.Text = descripcion;
            txtCodigo.Text = codigo;
            txtStock.Text = stock;
            txtPrecioCompra.Text = precioCompra;
            txtPrecioVenta.Text = precioVenta;
            txtInfoNutricional.Text = infonutricional;
            txtStockMinimo.Text = stockminimo;
            txtStockLimite.Text = stocklimite;

            // Establecer la selección del ComboBox de categoría
            foreach (OpcionCombo item in cmbCategoria.Items)
            {
                if (item.Valor.ToString() == categoria.ToString())
                {
                    cmbCategoria.SelectedItem = item;
                    break;
                }
            }

            // Luego de seleccionar la categoría, cargar las subcategorías correspondientes
            if (cmbCategoria.SelectedItem != null)
            {
                cmbCategoria_SelectedIndexChanged(null, EventArgs.Empty);

                // Establecer la selección del ComboBox de subcategoría
                foreach (OpcionCombo item in cmbSubCategoria.Items)
                {
                    if (item.Valor.ToString() == subcategoria.ToString())
                    {
                        cmbSubCategoria.SelectedItem = item;
                        break;
                    }
                }

                // Luego de seleccionar la subcategoría, cargar las subcategorías 2 correspondientes
                if (cmbSubCategoria2.SelectedItem != null)
                {
                    cmbSubCategoria_SelectedIndexChanged(null, EventArgs.Empty);

                    // Establecer la selección del ComboBox de subcategoría 2
                    foreach (OpcionCombo item in cmbSubCategoria2.Items)
                    {
                        if (item.Valor.ToString() == subcategoria2.ToString())
                        {
                            cmbSubCategoria2.SelectedItem = item;
                            break;
                        }
                    }
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
    }
}
