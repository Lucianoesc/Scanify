using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        bool menulateralExpandido;
        public FrmInicioEmpleados()
        {
            InitializeComponent();
        }
        private void abrirFormHijo(Form formHijo)
        {
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
            btnActualizarGrafConsultas_Click(sender, e);
            btnActualizarGrafPedStock_Click(sender, e);
            btnHome_Click(sender, e);
            List<Oferta> listaOfertas = new CN_Oferta().Listar();
            List<Producto> listaProductos = new CN_Producto().Listar();
            List<Usuario> listaUsuarios = new CN_Usuario().Listar();
            List<Proveedor> listaProveedores = new CN_Proveedor().Listar();
            List<Categoria> listaCategorias = new CN_Categoria().Listar();


            lblOfertas.Text = listaOfertas.Count.ToString();
            lblcantprod.Text = listaProductos.Count.ToString();
            lblempleados.Text = listaUsuarios.Count.ToString();
            lblProveedores.Text = listaProveedores.Count.ToString();
            lblCategorias.Text = listaCategorias.Count.ToString();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (FormActivo != null)
            {
                FormActivo.Dispose();

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

        private void btnUsuarios_Click(object sender, EventArgs e)
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

        private void btnActualizarGrafConsultas_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos de los productos más consultados en la semana
                List<Consulta> productosConsultados = cnConsulta.ObtenerProductosMasConsultadosPorSemana();

                // Limpiar el gráfico de datos anteriores (si los hay)
                chart1.Series.Clear();

                // Crear una nueva serie para el gráfico de pastel
                Series serie = new Series("Productos Consultados");
                serie.ChartType = SeriesChartType.Pie;

                // Agregar los datos al gráfico de pastel
                foreach (var producto in productosConsultados)
                {
                    serie.Points.AddXY(producto.Producto, producto.Consultas);
                }

                // Agregar la serie al gráfico
                chart1.Series.Add(serie);

                // Mostrar el gráfico
                chart1.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
                MessageBox.Show($"Error al obtener datos para el gráfico: {ex.Message}");
            }
        }

        private void btnActualizarGrafPedStock_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener todos los datos de productos y cantidades de pedidos
                List<PedidoStock> productosConCantidad = cnPedidoStock.ObtenerProductosConCantidad();

                // Limpiar los puntos de datos anteriores (si los hay)
                chartPedidoStock.Series.Clear();

                // Ordenar la lista por la cantidad de pedidos en orden descendente
                productosConCantidad = productosConCantidad.OrderBy(x => x.Pedidos).ToList();

                // Tomar los primeros 10 productos (o menos si hay menos de 10)
                int cantidadAMostrar = Math.Min(productosConCantidad.Count, 10);

                // Crear una nueva serie para el gráfico
                Series serie = new Series("Pedidos de Stock");
                chartPedidoStock.Legends.Clear();


                serie.ChartType = SeriesChartType.Bar;

                // Agregar los productos con mayor pedido al gráfico
                for (int i = 0; i < cantidadAMostrar; i++)
                {
                    serie.Points.AddXY(productosConCantidad[i].Producto, productosConCantidad[i].Pedidos);
                }

                // Agregar la serie al gráfico
                chartPedidoStock.Series.Add(serie);


                // Mostrar el gráfico
                chartPedidoStock.Visible = true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
                MessageBox.Show($"Error al obtener datos para el gráfico: {ex.Message}");
            }


        }
    }
}
