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
                oconexion.Open();
                using (SqlCommand cmd = new SqlCommand("SP_INSERTAR_BITACORA", oconexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdUsuario", int.Parse(idusuario));
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Evento", evento);
                    cmd.Parameters.AddWithValue("@Detalle", detalle);
                    cmd.Parameters.AddWithValue("@Origen", origen);
                    cmd.ExecuteNonQuery();
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
                catch (Exception)
                {
                    Lista = new List<Bitacora>();
                }
            }

            return Lista;
        }
    }

}
