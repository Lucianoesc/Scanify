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
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdNegocio, Nombre, CUIT, Direccion,CodigoSeguridad ,Foto from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                CUIT = dr["CUIT"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                CodigoSeguridad = dr["CodigoSeguridad"].ToString(),
                                Foto = (byte[])dr["Foto"]
                            };
                        }
                    }

                }
            }
            catch
            {
                obj = new Negocio();
            }
            return obj;
        }

        public bool Guardar(Negocio objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Nombre = @nombre,");
                    query.AppendLine("CUIT = @cuit,");
                    query.AppendLine("Direccion = @direccion,");
                    query.AppendLine("CodigoSeguridad = @CodigoSeguridad ");  // Agrega una coma aquí
                    query.AppendLine("WHERE IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@cuit", objeto.CUIT);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);
                    cmd.Parameters.AddWithValue("@CodigoSeguridad", objeto.CodigoSeguridad);

                    // Ejecutar la consulta
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar los datos del negocio";
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


        public byte[] ObtenerFoto(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "Select Foto from Negocio where IdNegocio = 1";

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
                    query.AppendLine("update Negocio set Foto = @imagen");
                    query.AppendLine("where IdNegocio = 1;");

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
