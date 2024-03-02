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
    public class CD_Producto
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> Lista = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarProductos", oconexion))
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
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Codigo = dr["Codigo"].ToString(),
                                    oCategoria = new Categoria()
                                    {
                                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    },
                                    oSubCategoria = new SubCategoria()
                                    {
                                        IdSubCategoria = Convert.ToInt32(dr["IdSubCategoria"]),

                                    },
                                    oSubCategoria2 = new SubCategoria2()
                                    {
                                        IdSubCategoria2 = Convert.ToInt32(dr["IdSubCategoria2"]),
                                    },
                                    Stock = Convert.ToInt32(dr["Stock"]),
                                    PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    InformacionNutricional = dr["informacionNutricional"].ToString(),
                                    Foto = (byte[])dr["Foto"],
                                    StockMinimo = Convert.ToInt32(dr["StockMinimo"]),
                                    StockLimite = Convert.ToInt32(dr["StockLimite"])
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
        
        public int Registrar(Producto obj, byte[] imagen, out string Mensaje)
        {
            int idProductogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@IdSubCategoria", obj.oSubCategoria.IdSubCategoria);
                    cmd.Parameters.AddWithValue("@IdSubCategoria2", obj.oSubCategoria2.IdSubCategoria2);
                    cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("@PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@informacionNutricional", obj.InformacionNutricional);
                    cmd.Parameters.AddWithValue("@Foto", imagen);
                    cmd.Parameters.AddWithValue("@StockMinimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("@StockLimite", obj.StockLimite);
                    cmd.Parameters.Add("@IdGenerado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idProductogenerado = Convert.ToInt32(cmd.Parameters["@IdGenerado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }

            return idProductogenerado;
        }
        
        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ModificarProducto".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("@Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@IdSubCategoria", obj.oSubCategoria.IdSubCategoria);
                    cmd.Parameters.AddWithValue("@IdSubCategoria2", obj.oSubCategoria2.IdSubCategoria2);
                    cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("@PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@informacionNutricional", obj.InformacionNutricional);
                    cmd.Parameters.AddWithValue("@StockMinimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("@StockLimite", obj.StockLimite);

                    cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
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

        public byte[] ObtenerFoto(int idProducto, out bool obtenido)
        {
            obtenido = true;
            byte[] FotoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SP_ObtenerFotoProducto";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
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


        public bool ActualizarFoto(int idProducto, byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SP_ActualizarFotoProducto", conexion);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.AddWithValue("@Foto", imagen);
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

        public Producto ObtenerProductoConOferta(int idProducto)
        {
            Producto producto = null;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarProductosConOferta", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                        conexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                producto = new Producto
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    // Otras propiedades aquí...
                                    oOferta = new Oferta
                                    {
                                        IdOferta = Convert.ToInt32(dr["IdOferta"]),
                                        NombreOferta = dr["NombreOferta"].ToString(),
                                        Descuento = Convert.ToDecimal(dr["Descuento"]),
                                    }
                                };
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    producto = null;
                }
            }

            return producto;
        }
        public List<Producto> ListarProductosPorIdSubCategoria2(int idSubcategoria2)
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarProductosPorIdSubCategoria2", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSubCategoria2", idSubcategoria2);

                        conexion.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Codigo = dr["Codigo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    oCategoria = new Categoria()
                                    {
                                        IdCategoria = Convert.ToInt32(dr["IdCategoria"])
                                    },
                                    oSubCategoria = new SubCategoria()
                                    {
                                        IdSubCategoria = Convert.ToInt32(dr["IdSubCategoria"])
                                    },
                                    oSubCategoria2 = new SubCategoria2()
                                    {
                                        IdSubCategoria2 = Convert.ToInt32(dr["IdSubCategoria2"])
                                    },
                                    Stock = Convert.ToInt32(dr["Stock"]),
                                    PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    InformacionNutricional = dr["InformacionNutricional"].ToString(),
                                    Foto = (byte[])dr["Foto"],
                                    StockMinimo = Convert.ToInt32(dr["StockMinimo"]),
                                    StockLimite = Convert.ToInt32(dr["StockLimite"])
                                });
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Producto>();
                }
            }

            return lista;
        }




    }
}
