using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> Lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("ListarPermisos", oconexion))
                    {
                        cmd.Parameters.AddWithValue("@idusuario", idusuario);
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Lista.Add(new Permiso()
                                {
                                    oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                    NombreMenu = dr["NombreMenu"].ToString(),
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Lista = new List<Permiso>();
                }
            }

            return Lista;
        }
    }
}
