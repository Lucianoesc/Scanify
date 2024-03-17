using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PedidoStock
    {
        public List<PedidoStock> ObtenerProductosConCantidad()
        {
            List<PedidoStock> productosConCantidad = new List<PedidoStock>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ContarPedidosPorSemana", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PedidoStock pedido = new PedidoStock();
                        pedido.Producto = reader["Producto"].ToString();
                        pedido.Pedidos = Convert.ToInt32(reader["Pedidos"]);
                        productosConCantidad.Add(pedido);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos y cantidades: {ex.Message}");
                throw;
            }

            return productosConCantidad;
        }


        public bool RegistrarPedidoStock(PedidoStock escaneo)
        {
            bool resultado = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarPedidosDeStock", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@IdProducto", escaneo.IdProducto);
                    cmd.Parameters.AddWithValue("@FechaPedidoStock", escaneo.FechaPedidoStock);

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                }
                catch (Exception)
                {

                }
            }

            return resultado;
        }
    }
}
