using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Legales
    {
        public Legales ObtenerDatos()
        {
            Legales obj = new Legales();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdLegales, Nombre, CUIT, Direccion from Legales where IdLegales = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Legales()
                            {
                                IdLegales = int.Parse(dr["IdLegales"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                CUIT = dr["CUIT"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            };
                        }
                    }

                }
            }
            catch
            {
                obj = new Legales();
            }
            return obj;
        }

        public bool Guardar(Legales objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update LEGALES set Nombre = @nombre,");
                    query.AppendLine("CUIT = @cuit,");
                    query.AppendLine("Direccion = @direccion");
                    query.AppendLine("where IdLegales = 1;");
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public byte[] ObtenerFoto(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "Select Foto from Legales where IdLegales = 1";

                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Foto"];
                        }
                    }
                }
            }
            catch
            {
                obtenido = false;
                LogoBytes = new byte[0];
            }
            return LogoBytes;
        }


        public bool ActualizarFoto(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Legales set Foto = @imagen");
                    query.AppendLine("where IdLegales = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar la foto";
                        respuesta = false;
                    }

                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }






    }
}
