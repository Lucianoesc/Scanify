using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion
{
    public partial class FrmInicioEmpleados : Form
    {
        private CN_Consulta cnConsulta = new CN_Consulta();

        private CN_PedidoStock cnPedidoStock = new CN_PedidoStock();
        private Form FormActivo = null;
        private static Usuario usuarioActual;

        bool menulateralExpandido;
        public FrmInicioEmpleados(Usuario objUsuario)
        {
            InitializeComponent();
            usuarioActual = objUsuario;

        }
        private void abrirFormHijo(Form formHijo)
        {
            // Verificar si el formulario ya está abierto
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formHijo.GetType())
                {
                    // Si el formulario ya está abierto, llevarlo al frente y salir del método
                    form.BringToFront();
                    return;
                }
            }

            // Si el formulario no está abierto, proceder a abrirlo
            if (FormActivo != null)
                FormActivo.Dispose();

            FormActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelFormHijos.Controls.Add(formHijo);
            panelFormHijos.Tag = formHijo;
            formHijo.BringToFront();

            formHijo.Show();

        }
        private void FrmInicioEmpleados_Load(object sender, EventArgs e)
        {

            btnHome.Focus();
            //btnActualizarGrafConsultas_Click(sender, e);
            //btnActualizarGrafPedStock_Click(sender, e);
            List<Oferta> listaOfertas = new CN_Oferta().Listar();
            List<Producto> listaProductos = new CN_Producto().Listar();
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            List<Proveedor> listaProveedores = new CN_Proveedor().Listar();
            List<Categoria> listaCategorias = new CN_Categoria().Listar();
            List<Bitacora> listaBitacora = new CN_Bitacora().ListarBitacora();

            List<Permiso> listaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (Panel panel in menulateral.Controls.OfType<Panel>())
            {
                // Verifica si el nombre del panel es igual a "PanelMenu" sin importar mayúsculas o minúsculas
                if (string.Equals(panel.Name, "PanelMenu", StringComparison.OrdinalIgnoreCase))
                {
                    // Si el nombre del panel es "PanelMenu", no cambies su visibilidad
                    continue;
                }

                bool encontrado = listaPermisos.Any(m => m.NombreMenu == panel.Name);

                if (encontrado == false)
                {
                    panel.Visible = false;
                }
            }
            lblNombreUsuario.Text = "(" + usuarioActual.Username + ")";
            lblNombre.Text = usuarioActual.Nombre;
            lblApellido.Text = usuarioActual.Apellido;
            txtBitacora.Text = listaBitacora.Count.ToString();
            lblOfertas.Text = listaOfertas.Count.ToString();
            lblcantprod.Text = listaProductos.Count.ToString();
            lblempleados.Text = listaUsuarios.Count.ToString();
            lblProveedores.Text = listaProveedores.Count.ToString();
            lblCategorias.Text = listaCategorias.Count.ToString();

            foreach (Producto producto in listaProductos)
            {

            }
            // Obtener la lista de productos

            // Filtrar la lista de productos para obtener aquellos con stock por debajo del stock mínimo
            List<Producto> productosBajoStockMinimo = listaProductos.Where(p => p.Stock < p.StockMinimo).ToList();

            // Contar la cantidad de productos por debajo del stock mínimo
            int cantidadProductosBajoStockMinimo = productosBajoStockMinimo.Count;

            // Mostrar la cantidad de productos por debajo del stock mínimo en el TextBox correspondiente
            txtStockMinimo.Text = cantidadProductosBajoStockMinimo.ToString();


            // Filtrar la lista de productos para obtener aquellos con stock por encima del stock límite
            List<Producto> productosEncimaStockLimite = listaProductos.Where(p => p.Stock > p.StockLimite).ToList();

            // Contar la cantidad de productos por encima del stock límite
            int cantidadProductosEncimaStockLimite = productosEncimaStockLimite.Count;

            // Mostrar la cantidad de productos por encima del stock límite en el TextBox correspondiente
            txtStockLimite.Text = cantidadProductosEncimaStockLimite.ToString();


            if (Usuario.Visible== true)
            {
                PanelUsuarios.Visible = true;
            }
            if (Consulta.Visible == true)
            {
                panelReporteConsultas.Visible = true;
            }
            if (ReportePedidoStock.Visible == true)
            {
                panelReporteStock.Visible = true;
            }
            if (ReportePedidos.Visible == true)
            {
                panelReportePedidos.Visible = true;
            }
            if (ReporteCompras.Visible == true)
            {
                panelReporteCompras.Visible = true;
            }
            if (Producto.Visible == true)
            {
                panelCrearProducto.Visible = true;
            }
            if (Categoria.Visible == true)
            {
                panelAccesoCategorias.Visible = true;
            }
            if (Proveedor.Visible == true)
            {
                panelProveedores.Visible = true;
            }
            if (RegistrarCompra.Visible == true)
            {
                panelRegistrarCompra.Visible = true;
            }
            if (RegistrarPedido.Visible == true)
            {
                panelCrearPedido.Visible = true;
            }
            if (Legales.Visible == true)
            {
                panelNegocio.Visible = true;
            }
            if (Promocion.Visible == true)
            {
                panelPromociones.Visible = true;
            }
            if (Promocion.Visible == true)
            {
                panelPromocionar.Visible = true;
            }
            if (Bitacora.Visible == true)
            {
                panelBitacora.Visible = true;
            }
            if (RegistrarCompra.Visible == false)
            {
                panelDetallesDeCompras.Visible = true;
            }
            if (RegistrarPedido.Visible == false)
            {
                panelDetallesDePedidos.Visible = true;
            }
        }

        private void menuBoton_Click(object sender, EventArgs e)
        {
            menulateralTimer.Start();

        }

        private void menulateralTimer_Tick(object sender, EventArgs e)
        {
            if (menulateralExpandido)
            {
                // si el menu está expandido, minimizarlo
                menulateral.Width -= 10;
                if (menulateral.Width == menulateral.MinimumSize.Width)
                {
                    menulateralExpandido = false;
                    menulateralTimer.Stop();
                }
            }
            else
            {
                menulateral.Width += 10;
                if (menulateral.Width == menulateral.MaximumSize.Width)
                {
                    menulateralExpandido = true;
                    menulateralTimer.Stop();
                }
            }
        }

        

        //private void btnActualizarGrafConsultas_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtener datos de los productos más consultados en la semana
        //        List<Consulta> productosConsultados = cnConsulta.ObtenerProductosMasConsultadosPorSemana();

        //        // Limpiar el gráfico de datos anteriores (si los hay)
        //        chart1.Series.Clear();

        //        // Crear una nueva serie para el gráfico de pastel
        //        Series serie = new Series("Productos Consultados");
        //        serie.ChartType = SeriesChartType.Pie;

        //        // Agregar los datos al gráfico de pastel
        //        foreach (var producto in productosConsultados)
        //        {
        //            serie.Points.AddXY(producto.Producto, producto.Consultas);
        //        }

        //        // Agregar la serie al gráfico
        //        chart1.Series.Add(serie);

        //        // Mostrar el gráfico
        //        chart1.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
        //        MessageBox.Show($"Error al obtener datos para el gráfico: {ex.Message}");
        //    }
        //}

        //private void btnActualizarGrafPedStock_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Obtener todos los datos de productos y cantidades de pedidos
        //        List<PedidoStock> productosConCantidad = cnPedidoStock.ObtenerProductosConCantidad();

        //        // Limpiar los puntos de datos anteriores (si los hay)
        //        chartPedidoStock.Series.Clear();

        //        // Ordenar la lista por la cantidad de pedidos en orden descendente
        //        productosConCantidad = productosConCantidad.OrderBy(x => x.Pedidos).ToList();

        //        // Tomar los primeros 10 productos (o menos si hay menos de 10)
        //        int cantidadAMostrar = Math.Min(productosConCantidad.Count, 10);

        //        // Crear una nueva serie para el gráfico
        //        Series serie = new Series("Pedidos de Stock");
        //        chartPedidoStock.Legends.Clear();


        //        serie.ChartType = SeriesChartType.Bar;

        //        // Agregar los productos con mayor pedido al gráfico
        //        for (int i = 0; i < cantidadAMostrar; i++)
        //        {
        //            serie.Points.AddXY(productosConCantidad[i].Producto, productosConCantidad[i].Pedidos);
        //        }

        //        // Agregar la serie al gráfico
        //        chartPedidoStock.Series.Add(serie);


        //        // Mostrar el gráfico
        //        chartPedidoStock.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
        //        MessageBox.Show($"Error al obtener datos para el gráfico: {ex.Message}");
        //    }


        //}

        private void FrmInicioEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                picCerrar_Click(sender, e);
            }
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picCerrar_Click(object sender, EventArgs e)
        {
            ModalSalirDashboard mod = new ModalSalirDashboard();
            mod.ShowDialog();
            this.Dispose();
            this.Close();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmCategoria());

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmProveedores());

        }

     

       

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmDetallePedido());

        }

        private void btnOfertas_Productos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmOfertas_Productos());
        }

        private void btnDetalleCompra_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmDetalleCompra(usuarioActual));

        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (FormActivo != null)
            {
                FormActivo.Dispose();

            }
        }

        private void menulateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmEmpleados());

        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmReporteConsultas());

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmProductos());

        }

        private void btnCategorias_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmCategoria());

        }

        private void btnProveedores_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmProveedores());

        }

        private void btnCompras_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmRegistrarCompra(usuarioActual));

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmPedido(usuarioActual));

        }

        private void btnNegocio_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmNegocio(usuarioActual));

        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmBitacora());

        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmOfertas());

        }

        private void BtnReportePedidoStock_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmReportePedidoStock());

        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmReporteCompra());

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmReportePedidos());

        }

        private void panelFormHijos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticonePictureBox4_Click(object sender, EventArgs e)
        {
            btnCategorias.PerformClick();
        }

        private void siticonePictureBox6_Click(object sender, EventArgs e)
        {
            btnCompras.PerformClick();
        }

        private void siticonePanel4_Click(object sender, EventArgs e)
        {
            btnProductos.PerformClick();
        }

        private void siticonePanel5_Click(object sender, EventArgs e)
        {
            btnPedidos.PerformClick();
        }

        private void siticonePictureBox13_Click(object sender, EventArgs e)
        {
            btnUsuarios.PerformClick();
        }

        private void siticonePictureBox17_Click(object sender, EventArgs e)
        {
            btnProveedores.PerformClick();
        }

        private void siticonePictureBox2_Click(object sender, EventArgs e)
        {
            btnPromociones.PerformClick();
        }

        private void siticonePictureBox28_Click_1(object sender, EventArgs e)
        {
            btnNegocio.PerformClick();
        }

        private void siticonePanel13_Click(object sender, EventArgs e)
        {
            FrmInicioEmpleados frm = Application.OpenForms.OfType<FrmInicioEmpleados>().FirstOrDefault() ?? new FrmInicioEmpleados(usuarioActual);

            // Encuentra el panel llamado "DetallePedido" en el formulario FrmInicioEmpleados
            Panel panelDetallePedido = frm.Controls.Find("Promocionar", true).FirstOrDefault() as Panel;

            if (panelDetallePedido != null)
            {


                panelDetallePedido.Visible = true;
                Button btn = frm.Controls.Find("btnOfertas_Productos", true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    Color colorOriginal = btn.ForeColor;
                    Image imageOriginal = btn.Image;
                    btn.ForeColor = Color.White;
                    btn.Image = null;
                    btn.PerformClick();
                    panelDetallePedido.Visible = false;
                    btn.ForeColor = colorOriginal;
                    btn.Image = imageOriginal;
                }



            }
        }

        private void siticonePictureBox16_Click(object sender, EventArgs e)
        {
            BtnReportePedidoStock.PerformClick();
        }

        private void siticonePictureBox12_Click(object sender, EventArgs e)
        {
            btnReporteCompras.PerformClick();
        }

        private void siticonePictureBox18_Click(object sender, EventArgs e)
        {
            btnReportePedidos.PerformClick();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            btnConsultas.PerformClick();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            btnBitacora.PerformClick();
        }

        private void siticonePictureBox32_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmInicioEmpleados
            FrmInicioEmpleados frm = Application.OpenForms.OfType<FrmInicioEmpleados>().FirstOrDefault() ?? new FrmInicioEmpleados(usuarioActual);

            // Encuentra el panel llamado "DetallePedido" en el formulario FrmInicioEmpleados
            Panel panelDetalleCompra = frm.Controls.Find("DetalleCompra", true).FirstOrDefault() as Panel;

            if (panelDetalleCompra != null)
            {


                panelDetalleCompra.Visible = true;
                Button btn = frm.Controls.Find("btnDetalleCompra", true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    System.Drawing.Color colorOriginal = btn.ForeColor;
                    Image imageOriginal = btn.Image;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.Image = null;
                    btn.PerformClick();
                    panelDetalleCompra.Visible = false;
                    btn.ForeColor = colorOriginal;
                    btn.Image = imageOriginal;
                }



            }
        }

        private void panelDetallesDePedidos_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario FrmInicioEmpleados
            FrmInicioEmpleados frm = Application.OpenForms.OfType<FrmInicioEmpleados>().FirstOrDefault() ?? new FrmInicioEmpleados(usuarioActual);

            // Encuentra el panel llamado "DetallePedido" en el formulario FrmInicioEmpleados
            Panel panelDetallePedido = frm.Controls.Find("DetallePedido", true).FirstOrDefault() as Panel;

            if (panelDetallePedido != null)
            {


                panelDetallePedido.Visible = true;
                Button btn = frm.Controls.Find("btnDetallePedido", true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    Color colorOriginal = btn.ForeColor;
                    Image imageOriginal = btn.Image;
                    btn.ForeColor = Color.White;
                    btn.Image = null;
                    btn.PerformClick();
                    panelDetallePedido.Visible = false;
                    btn.ForeColor = colorOriginal;
                    btn.Image = imageOriginal;
                }



            }
        }
    }
}
