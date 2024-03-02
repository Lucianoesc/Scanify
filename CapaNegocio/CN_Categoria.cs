using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using static System.Net.Mime.MediaTypeNames;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objcd_Categoria = new CD_Categoria();

        public List<Categoria> Listar()
        {
            return objcd_Categoria.Listar();

        }
        public int Registrar(Categoria obj, byte[] fotocategoria, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la Categoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Categoria.Registrar(obj, fotocategoria, out Mensaje);
            }


        }
        public bool Editar(Categoria obj, byte[] fotocategoria, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la Categoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                if (fotocategoria != null)
                {
                    bool respuestaImagen = ActualizarFotoCategoria(obj.IdCategoria, fotocategoria, out Mensaje);

                    if (!respuestaImagen)
                    {
                        Mensaje = "No se pudo asociar la nueva imagen a la Categoria";
                        return false;
                    }
                }

                return objcd_Categoria.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return objcd_Categoria.Eliminar(obj, out Mensaje);

        }

        public byte[] ObtenerFotoCategoria(int idCategoria, out bool obtenido)
        {
            return objcd_Categoria.ObtenerFotoCategoria(idCategoria, out obtenido);
        }
        
        public bool ActualizarFotoCategoria(int idCategoria, byte[] fotocategoria, out string mensaje)
        {
            return objcd_Categoria.ActualizarFotoCategoria(idCategoria, fotocategoria, out mensaje);
        }
    }
}
