﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using BCrypt.Net;

using System.Security.Cryptography;




namespace CapaDatos
{
    public class CD_Usuario
    {
        // Este metodo devuelve una lista de usuarios
        public List<Usuario> Listar()
        {
            List<Usuario> Lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("ListarUsuarios", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                Usuario usuario = new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Username = dr["Username"].ToString(),
                                    Documento = dr["Documento"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                                };

                                // Verificar si el campo DigitoVerificador no es nulo y tiene al menos un carácter
                                if (dr["DigitoVerificador"] != DBNull.Value && !string.IsNullOrEmpty(dr["DigitoVerificador"].ToString()))
                                {
                                    usuario.DigitoVerificador = dr["DigitoVerificador"].ToString()[0];
                                }

                                Lista.Add(usuario);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Manejar excepciones de SQL
                    Console.WriteLine("Error de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar otras excepciones
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return Lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    cmd.Parameters.AddWithValue("@Username", obj.Username);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);

                    // En lugar de pasar la contraseña, pasa el hash de la contraseña
                    string hashClave = BCrypt.Net.BCrypt.HashPassword(obj.Clave);
                    cmd.Parameters.AddWithValue("@Clave", hashClave);

                    cmd.Parameters.AddWithValue("@IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("@IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["@IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return idusuariogenerado;
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Username", obj.Username);

                    // En lugar de pasar la contraseña, pasa el hash de la contraseña
                    string hashClave = BCrypt.Net.BCrypt.HashPassword(obj.Clave);
                    cmd.Parameters.AddWithValue("Clave", hashClave);


                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
        public bool ActualizarDigitoVerificador(int idUsuario, out char digitoVerificador, out string mensaje)
        {
            bool exito = false;
            digitoVerificador = '\0';
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_DIGITO_VERIFICADOR", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    // Parámetros de salida
                    SqlParameter digitoVerificadorParam = new SqlParameter("@DigitoVerificador", SqlDbType.Char, 1);
                    digitoVerificadorParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(digitoVerificadorParam);

                    SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500);
                    mensajeParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParam);

                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener los valores de los parámetros de salida
                    digitoVerificador = Convert.ToChar(cmd.Parameters["@DigitoVerificador"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    exito = true;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                // Manejar la excepción según sea necesario
            }

            return exito;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }


            return respuesta;
        }


    }

}
