using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_SubCategoria
    {
        private CD_SubCategoria objcd_SubCategoria = new CD_SubCategoria();

        public List<SubCategoria> Listar()
        {
            return objcd_SubCategoria.Listar();

        }
        public List<SubCategoria> ListarPorIdCategoria(int idCategoria)
        {
            return objcd_SubCategoria.ListarPorIdCategoria(idCategoria);
        }
        public int Registrar(SubCategoria obj, byte[] fotosubcategoria, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la SubCategoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_SubCategoria.Registrar(obj, fotosubcategoria, out Mensaje);
            }


        }
        public bool Editar(SubCategoria obj, byte[] fotosubcategoria, out string Mensaje)
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
                if (fotosubcategoria != null)
                {
                    bool respuestaImagen = ActualizarFotoSubCategoria(obj.IdSubCategoria, fotosubcategoria, out Mensaje);

                    if (!respuestaImagen)
                    {
                        Mensaje = "No se pudo asociar la nueva imagen a la SubCategoria";
                        return false;
                    }
                }

                return objcd_SubCategoria.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(SubCategoria obj, out string Mensaje)
        {
            return objcd_SubCategoria.Eliminar(obj, out Mensaje);

        }

        public byte[] ObtenerFotoSubCategoria(int idSubCategoria, out bool obtenido)
        {
            return objcd_SubCategoria.ObtenerFotoSubCategoria(idSubCategoria, out obtenido);
        }

        public bool ActualizarFotoSubCategoria(int idSubCategoria, byte[] fotosubcategoria, out string mensaje)
        {
            return objcd_SubCategoria.ActualizarFotoSubCategoria(idSubCategoria, fotosubcategoria, out mensaje);
        }
        



    }
}
