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
    public class CD_ReportePedidoStock
    {
        public List<ReportePedidoStock> PedidoStocks(string fechaInicio, string fechaFin, int idProducto)
        {
            List<ReportePedidoStock> lista = new List<ReportePedidoStock>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ReportePedidoStock", conexion);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReportePedidoStock
                            {
                                HoraPedidoStock = dr["HoraPedido"].ToString(),
                                FechaPedidoStock = dr["FechaPedido"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Se produjo una excepción: " + ex.Message);
                }
            }

            return lista;
        }
    }
}
