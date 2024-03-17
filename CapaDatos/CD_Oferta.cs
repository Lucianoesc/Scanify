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
    public class CD_Oferta
    {
        public List<Oferta> ListarOfertas()
        {
            List<Oferta> Lista = new List<Oferta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarOfertas", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Lista.Add(new Oferta()
                                {
                                    IdOferta = Convert.ToInt32(dr["IdOferta"]),
                                    NombreOferta = dr["NombreOferta"].ToString(),
                                    Descuento = Convert.ToDecimal(dr["Descuento"]),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"].ToString()),
                                    FechaFin = Convert.ToDateTime(dr["FechaFin"].ToString()),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    Foto = (byte[])dr["Foto"],
                                    PantallaPrincipal = (byte[])dr["PantallaPrincipal"]
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Lista = new List<Oferta>();
                }
            }

            return Lista;
        }


        public int Registrar(Oferta obj, byte[] imagen, byte[] pantallaprincipal, out string Mensaje)
        {
            int idOfertagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarOferta".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("NombreOferta", obj.NombreOferta);
                    cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                    cmd.Parameters.AddWithValue("FechaInicio", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", obj.FechaFin);
                    cmd.Parameters.AddWithValue("Foto", imagen);
                    cmd.Parameters.AddWithValue("PantallaPrincipal", pantallaprincipal);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdGenerado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idOfertagenerado = Convert.ToInt32(cmd.Parameters["IdGenerado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idOfertagenerado = 0;
                Mensaje = ex.Message;
            }

            return idOfertagenerado;
        }



        public bool Editar(Oferta obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarOferta".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdOferta", obj.IdOferta);
                    cmd.Parameters.AddWithValue("NombreOferta", obj.NombreOferta);
                    cmd.Parameters.AddWithValue("Descuento", obj.Descuento);
                    cmd.Parameters.AddWithValue("FechaInicio", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", obj.FechaFin);
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

        public bool Eliminar(Oferta obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarOferta".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdOferta", obj.IdOferta);
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
        public byte[] ObtenerFotoPrincipal(int idOferta, out bool obtenido2)
        {
            obtenido2 = true;
            byte[] FotoBytes = new byte[0];


            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SP_ObtenerPantallaPrincipalOferta";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@IdOferta", idOferta);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FotoBytes = (byte[])dr["PantallaPrincipal"];

                        }
                    }
                }
            }
            catch (Exception)
            {
                obtenido2 = false;
                FotoBytes = new byte[0];

            }

            return FotoBytes;
        }

        public byte[] ObtenerFoto(int idOferta, out bool obtenido)
        {
            obtenido = true;
            byte[] FotoBytes = new byte[0];


            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SP_ObtenerFotoOferta";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@IdOferta", idOferta);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FotoBytes = (byte[])dr["Foto"];

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


        public bool ActualizarFoto(int idOferta, byte[] imagen, byte[] pantallaprincipal, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ActualizarFotoOferta", conexion);
                    cmd.Parameters.AddWithValue("@IdOferta", idOferta);
                    cmd.Parameters.AddWithValue("@Foto", imagen);
                    cmd.Parameters.AddWithValue("@PantallaPrincipal", pantallaprincipal);

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


        public bool AsociarProductosAOferta(int idOferta, List<int> productosSeleccionados, out string mensaje)
        {
            // Lógica para asociar productos a una oferta en la base de datos
            // Utiliza un procedimiento almacenado o sentencia SQL para realizar la actualización

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    foreach (int idProducto in productosSeleccionados)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_AsociarProductoAOferta", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                            cmd.Parameters.AddWithValue("@IdOferta", idOferta);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                mensaje = "Productos asociados con éxito";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al asociar productos: " + ex.Message;
                return false;
            }
        }

        public bool DesasociarProductosDeOferta(int idOferta, List<int> productosDesasociar, out string mensaje)
        {

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    foreach (int idProducto in productosDesasociar)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DesasociarProductoDeOferta", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                mensaje = "Productos desasociados con éxito";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "Error al desasociar productos: " + ex.Message;
                return false;
            }
        }


        public List<Producto> ListarProductos_Oferta()
        {
            List<Producto> Lista = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarProductos_Oferta", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Lista.Add(new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Codigo = dr["Codigo"].ToString(),
                                    oCategoria = new Categoria()
                                    {
                                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                        Descripcion = dr["DescripcionCategoria"].ToString()
                                    },
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Lista = new List<Producto>();
                }
            }

            return Lista;
        }

        public List<Producto> ListarProductosPorOferta(int idOferta)
        {
            List<Producto> ListaProductos = new List<Producto>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_ListarProductosPorOferta", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdOferta", idOferta);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto producto = new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Codigo = dr["Codigo"].ToString(),
                                    oCategoria = new Categoria()
                                    {
                                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                        Descripcion = dr["DescripcionCategoria"].ToString()
                                    },
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                };

                                ListaProductos.Add(producto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al obtener los productos de la oferta: " + ex.Message);
            }

            return ListaProductos;
        }
    }


}

