using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objcd_Producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return objcd_Producto.ListarProductos();
        }
        public Producto ObtenerProductoConOferta(int idProducto)
        {
            return objcd_Producto.ObtenerProductoConOferta(idProducto);
        }


        public int Registrar(Producto obj, byte[] imagen, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del producto\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el descripcion del producto\n";
            }
            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario del codigo del producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Producto.Registrar(obj, imagen, out Mensaje);
            }



        }

        public bool Editar(Producto obj, byte[] nuevaImagen, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del Producto\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario el descripcion del Producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Antes de editar, si hay una nueva imagen, actualiza la imagen en la base de datos
                if (nuevaImagen != null)
                {
                    bool respuestaImagen = ActualizarFoto(obj.IdProducto, nuevaImagen, out Mensaje);

                    if (!respuestaImagen)
                    {
                        Mensaje = "No se pudo asociar la nueva imagen al producto";
                        return false;
                    }
                }

                return objcd_Producto.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return objcd_Producto.Eliminar(obj, out Mensaje);
        }

        public byte[] ObtenerFoto(int idProducto, out bool obtenido)
        {
            return objcd_Producto.ObtenerFoto(idProducto, out obtenido);
        }

        public bool ActualizarFoto(int idProducto, byte[] imagen, out string mensaje)
        {
            return objcd_Producto.ActualizarFoto(idProducto, imagen, out mensaje);
        }
        public List<Producto> ObtenerProductosPorIdOferta(int idOferta)
        {
            return objcd_Producto.ObtenerProductosPorIdOferta(idOferta);
        }
    }
}
