using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Bitacora
    {
        public void InsertarBitacora(string usuario, string idusuario, string evento, string detalle, string origen)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_INSERTAR_BITACORA", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        // Intentar convertir idusuario a entero
                        int idUsuario;
                        if (int.TryParse(idusuario, out idUsuario))
                        {
                            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                            cmd.Parameters.AddWithValue("@Usuario", usuario);
                            cmd.Parameters.AddWithValue("@Evento", evento);
                            cmd.Parameters.AddWithValue("@Detalle", detalle);
                            cmd.Parameters.AddWithValue("@Origen", origen);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Manejar el caso en que idusuario no sea un número válido
                            Console.WriteLine("Error: idusuario no es un número válido");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier otra excepción que pueda ocurrir durante el proceso
                    Console.WriteLine("Error al insertar en la bitácora: " + ex.Message);
                }
            }
        }

        public List<Bitacora> ListarBitacora()
        {
            List<Bitacora> Lista = new List<Bitacora>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_LISTAR_BITACORA", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string fecha = dr["Fecha"].ToString();
                                string hora = dr["Hora"].ToString();

                                Bitacora bitacora = new Bitacora
                                {
                                    IdBitacora = (int)dr["IdBitacora"],
                                    Fecha = fecha,
                                    Hora = hora,
                                    IdUsuario = (int)dr["IdUsuario"],
                                    Usuario = dr["Usuario"].ToString(),
                                    Evento = dr["Evento"].ToString(),
                                    Detalle = dr["Detalle"].ToString(),
                                    Origen = dr["Origen"].ToString()
                                };
                                Lista.Add(bitacora);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante el proceso de listado
                    Console.WriteLine("Error al listar la bitácora: " + ex.Message);
                }
            }

            return Lista;
        }
    }

}
