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
        public List<Producto> ListarProductosPorIdSubCategoria2(int idSubCategoria2)
        {
            return objcd_Producto.ListarProductosPorIdSubCategoria2(idSubCategoria2);
        }
        public Producto ObtenerProductoConOferta(int idProducto)
        {
            return objcd_Producto.ObtenerProductoConOferta(idProducto);
        }

        public int Registrar(Producto obj, byte[] imagen, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre del producto\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje += "Es necesario la descripción del producto\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje += "Es necesario el código del producto\n";
            }

            if (!string.IsNullOrWhiteSpace(Mensaje))
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
            if (string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje += "Es necesario el código del Producto\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje += "Es necesario la descripción del Producto\n";
            }
            if (!string.IsNullOrWhiteSpace(Mensaje))
            {
                return false;
            }
            else
            {
                // Antes de editar, si hay una nueva imagen, actualiza la imagen en la base de datos
                if (nuevaImagen != null)
                {
                    bool respuestaImagen = objcd_Producto.ActualizarFoto(obj.IdProducto, nuevaImagen, out Mensaje);

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
    }
}
