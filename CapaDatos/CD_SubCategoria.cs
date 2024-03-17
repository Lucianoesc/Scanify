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
    public class CD_SubCategoria
    {
        public List<SubCategoria> Listar()
        {
            List<SubCategoria> Lista = new List<SubCategoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarSubCategoria", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Lista.Add(new SubCategoria()
                                {
                                    IdSubCategoria = Convert.ToInt32(dr["IdSubCategoria"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    oCategoria = new Categoria()
                                    {
                                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                        Descripcion = dr["DescripcionCategoria"].ToString()
                                    },
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    FotoSubCategoria = (byte[])dr["FotoSubCategoria"],

                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Lista = new List<SubCategoria>();
                }
            }

            return Lista;
        }
        public List<SubCategoria> ListarPorIdCategoria(int idCategoria)
        {
            List<SubCategoria> lista = new List<SubCategoria>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarSubCategoriaPorIdCategoria", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                        conexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new SubCategoria()
                                {
                                    IdSubCategoria = Convert.ToInt32(dr["IdSubCategoria"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    oCategoria = new Categoria()
                                    {
                                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                        Descripcion = dr["DescripcionCategoria"].ToString()
                                    },
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    FotoSubCategoria = (byte[])dr["FotoSubCategoria"],
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<SubCategoria>();
                }
            }

            return lista;
        }
        public int Registrar(SubCategoria obj, byte[] fotosubcategoria, out string Mensaje)
        {

            int idSubCategoriagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarSubCategoria".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);

                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("FotoSubCategoria", fotosubcategoria);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idSubCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idSubCategoriagenerado = 0;
                Mensaje = ex.Message;
            }


            return idSubCategoriagenerado;
        }


        public bool Editar(SubCategoria obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarSubCategoria".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdSubCategoria", obj.IdSubCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
        public bool Eliminar(SubCategoria obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarSubCategoria".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdSubCategoria", obj.IdSubCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
        public byte[] ObtenerFotoSubCategoria(int idSubCategoria, out bool obtenido)
        {
            obtenido = true;
            byte[] FotoBytes = new byte[0];


            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SP_ObtenerFotoSubCategoria";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idSubCategoria", idSubCategoria);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FotoBytes = (byte[])dr["FotoSubCategoria"];

                        }
                    }
                }
            }
            catch (Exception)
            {
                obtenido = false;
                FotoBytes = new byte[0];

            }

            return FotoBytes;
        }



        public bool ActualizarFotoSubCategoria(int idSubCategoria, byte[] fotosubcategoria, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ActualizarFotoSubCategoria", conexion);
                    cmd.Parameters.AddWithValue("@IdSubCategoria", idSubCategoria);
                    cmd.Parameters.AddWithValue("@FotoSubCategoria", fotosubcategoria);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
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
