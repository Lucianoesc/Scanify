using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();

        }


        private void Frm_ProductosActualizados(object sender, EventArgs e)
        {
            // Actualizar los productos en el FlowLayoutPanel
            CargarProductosEnFlowLayout();
        }
        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {

            Form background = new Form();
            try
            {
                using (ModalControladorProductos frm = new ModalControladorProductos())
                {
                    frm.ProductosActualizados += Frm_ProductosActualizados;

                    background.StartPosition = FormStartPosition.Manual;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = .50d;
                    background.BackColor = Color.Black;
                    background.WindowState = FormWindowState.Maximized;
                    background.Location = this.Location;
                    background.ShowInTaskbar = false;
                    background.Show();

                    frm.Owner = background;
                    frm.ShowDialog();
                    background.Dispose();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                background.Dispose();
            }






        }
        private void CargarProductosEnFlowLayout()
        {
            // Limpiar el FlowLayoutPanel antes de cargar los productos
            flowLayoutPanel1.Controls.Clear();

            // Crear una instancia de la capa de negocio de producto
            CN_Producto negocioProducto = new CN_Producto();

            // Obtener la lista de productos utilizando el método Listar de CN_Producto
            List<Producto> lista = negocioProducto.Listar();

            // Recorrer la lista de productos
            foreach (Producto producto in lista)
            {
                // Crear una instancia del control de usuario CartaControl
                CartaControl productoControl = new CartaControl();

                // Establecer los datos del producto en el control
                productoControl.Id = producto.IdProducto.ToString();
                productoControl.Titulo = producto.Nombre;
                productoControl.Descripcion = producto.Descripcion;
                productoControl.Codigo = producto.Codigo;
                productoControl.Categoria = producto.oCategoria.Descripcion;
                productoControl.Stock = producto.Stock.ToString();
                productoControl.PrecioCompra = producto.PrecioCompra.ToString();
                productoControl.PrecioVenta = producto.PrecioVenta.ToString();
                productoControl.InfoNutricional = producto.InformacionNutricional;
                productoControl.Estado = producto.Estado ? "Activo" : "Inactivo";

                productoControl.Foto = ByteAimagen(producto.Foto); // Asegúrate de que Foto sea un arreglo de bytes

                // Suscribirse al evento de productos actualizados
                productoControl.ProductosActualizados += Frm_ProductosActualizados;

                // Agregar el control al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(productoControl);
            }




        }
        public Image ByteAimagen(byte[] imagenBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes, 0, imagenBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            // Suscribirse al evento de productos actualizados para cada control CartaControl existente
            foreach (CartaControl cartaControl in flowLayoutPanel1.Controls.OfType<CartaControl>())
            {
                cartaControl.ProductosActualizados += Frm_ProductosActualizados;
            }

            // Cargar los productos en el FlowLayoutPanel
            CargarProductosEnFlowLayout();

            this.txtBuscador.TextChanged += new System.EventHandler(this.siticoneTextBox1_TextChanged);




        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscador.Text.Trim().ToUpper();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CartaControl cartaControl) // Reemplaza "CartaControl" con el nombre de tu control personalizado
                {
                    // Verificar si el título o el código del producto contienen el texto de búsqueda
                    bool encontrado = cartaControl.Titulo.ToUpper().Contains(textoBusqueda) ||
                                      cartaControl.Codigo.ToUpper().Contains(textoBusqueda);

                    // Mostrar u ocultar el control según el término de búsqueda
                    cartaControl.Visible = encontrado;
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                // Agregar las columnas al DataTable
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Descripción", typeof(string));
                dt.Columns.Add("Código", typeof(string));
                dt.Columns.Add("Categoría", typeof(string));
                dt.Columns.Add("Stock", typeof(string));
                dt.Columns.Add("PrecioCompra", typeof(string));
                dt.Columns.Add("PrecioVenta", typeof(string));
                dt.Columns.Add("Estado", typeof(string)); // Asegúrate de ajustar las columnas según tus necesidades

                // Recorrer los controles en el FlowLayoutPanel y agregar los datos al DataTable
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is CartaControl cartaControl) // Reemplaza "CartaControl" con el nombre de tu control personalizado
                    {
                        DataRow fila = dt.NewRow();

                        // Agregar los datos de cada control al DataTable
                        fila["Nombre"] = cartaControl.Titulo;
                        fila["Descripción"] = cartaControl.Descripcion;
                        fila["Código"] = cartaControl.Codigo;
                        fila["Categoría"] = cartaControl.Categoria; // Ajusta esto según cómo obtengas la categoría en tu control personalizado
                        fila["Stock"] = cartaControl.Stock;
                        fila["PrecioCompra"] = cartaControl.PrecioCompra;
                        fila["PrecioVenta"] = cartaControl.PrecioVenta;
                        fila["Estado"] = cartaControl.Estado;

                        dt.Rows.Add(fila);
                    }
                }

                // Guardar el archivo de Excel
                SaveFileDialog guardarArchivo = new SaveFileDialog();
                guardarArchivo.FileName = string.Format("Reporte_Producto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                guardarArchivo.Filter = "Excel files | *.xlsx";

                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");

                        // Ajustar el ancho de las columnas manualmente para que se ajusten al contenido
                        hoja.Column("A").Width = 20; // Ajusta el ancho de la columna A y asi
                        hoja.Column("B").Width = 50; 
                                                     

                        wb.SaveAs(guardarArchivo.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
