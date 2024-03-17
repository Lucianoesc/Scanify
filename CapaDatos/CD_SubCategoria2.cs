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
    public class CD_SubCategoria2
    {
        public List<SubCategoria2> Listar()
        {
            List<SubCategoria2> Lista = new List<SubCategoria2>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarSubCategoria2", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Lista.Add(new SubCategoria2()
                                {
                                    IdSubCategoria2 = Convert.ToInt32(dr["IdSubCategoria2"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    oSubCategoria = new SubCategoria()
                                    {
                                        IdSubCategoria = Convert.ToInt32(dr["IdSubCategoria"]),
                                        Descripcion = dr["DescripcionSubCategoria"].ToString()
                                    },
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    FotoSubCategoria2 = (byte[])dr["FotoSubCategoria2"],

                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Lista = new List<SubCategoria2>();
                }
            }

            return Lista;
        }
        public List<SubCategoria2> ListarPorIdSubCategoria(int idSubCategoria)
        {
            List<SubCategoria2> lista = new List<SubCategoria2>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarSubCategoriaPorIdSubCategoria", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSubCategoria", idSubCategoria);

                        conexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new SubCategoria2()
                                {
                                    IdSubCategoria2 = Convert.ToInt32(dr["IdSubCategoria2"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    oSubCategoria = new SubCategoria()
                                    {
                                        IdSubCategoria = Convert.ToInt32(dr["IdSubCategoria"]),
                                        Descripcion = dr["DescripcionSubCategoria"].ToString()
                                    },
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    FotoSubCategoria2 = (byte[])dr["FotoSubCategoria2"],
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<SubCategoria2>();
                }
            }

            return lista;
        }
        public int Registrar(SubCategoria2 obj, byte[] fotosubcategoria, out string Mensaje)
        {

            int idSubCategoria2generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarSubcategoria2".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdSubCategoria", obj.oSubCategoria.IdSubCategoria);

                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("FotoSubCategoria2", fotosubcategoria);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idSubCategoria2generado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idSubCategoria2generado = 0;
                Mensaje = ex.Message;
            }


            return idSubCategoria2generado;
        }


        public bool Editar(SubCategoria2 obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarSubCategoria2".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdSubCategoria2", obj.IdSubCategoria2);
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
        public bool Eliminar(SubCategoria2 obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarSubCategoria2".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdSubCategoria2", obj.IdSubCategoria2);
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
        public byte[] ObtenerFotoSubCategoria2(int idSubCategoria2, out bool obtenido)
        {
            obtenido = true;
            byte[] FotoBytes = new byte[0];


            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SP_ObtenerFotoSubCategoria2";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idSubCategoria2", idSubCategoria2);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FotoBytes = (byte[])dr["FotoSubCategoria2"];

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



        public bool ActualizarFotoSubCategoria2(int idSubCategoria2, byte[] fotosubcategoria, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ActualizarFotoSubCategoria2", conexion);
                    cmd.Parameters.AddWithValue("@IdSubCategoria2", idSubCategoria2);
                    cmd.Parameters.AddWithValue("@FotoSubCategoria2", fotosubcategoria);

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
