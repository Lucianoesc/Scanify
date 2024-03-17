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
    public class CD_Consulta
    {
        public List<Consulta> ObtenerProductosMasConsultadosPorSemana()
        {
            List<Consulta> productosMasConsultados = new List<Consulta>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ObtenerProductosMasConsultadosPorSemana", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Consulta producto = new Consulta();
                        producto.Producto = reader["Producto"].ToString();
                        producto.Consultas = Convert.ToInt32(reader["Consultas"]);
                        productosMasConsultados.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine($"Error al obtener productos consultados: {ex.Message}");
            }

            return productosMasConsultados;
        }

        public bool RegistrarEscaneo(Consulta escaneo)
        {
            bool resultado = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarEscaneos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@IdProducto", escaneo.IdProducto);
                    cmd.Parameters.AddWithValue("@FechaEscaneo", escaneo.FechaEscaneo);

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                }
                catch (Exception)
                {
                    // Manejar excepciones
                }
            }

            return resultado;
        }
    }
}
