using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_SubCategoria2
    {
        private CD_SubCategoria2 objcd_SubCategoria2 = new CD_SubCategoria2();

        public List<SubCategoria2> Listar()
        {
            return objcd_SubCategoria2.Listar();

        }
        public List<SubCategoria2> ListarPorIdSubCategoria(int idSubCategoria)
        {
            return objcd_SubCategoria2.ListarPorIdSubCategoria(idSubCategoria);
        }
        public int Registrar(SubCategoria2 obj, byte[] fotosubcategoria2, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la SubCategoria2\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_SubCategoria2.Registrar(obj, fotosubcategoria2, out Mensaje);
            }


        }
        public bool Editar(SubCategoria2 obj, byte[] fotosubcategoria2, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion de la subcategoria2\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                if (fotosubcategoria2 != null)
                {
                    bool respuestaImagen = ActualizarFotoSubCategoria2(obj.IdSubCategoria2, fotosubcategoria2, out Mensaje);

                    if (!respuestaImagen)
                    {
                        Mensaje = "No se pudo asociar la nueva imagen a la SubCategoria2";
                        return false;
                    }
                }

                return objcd_SubCategoria2.Editar(obj, out Mensaje);
            }
        }
        public bool Eliminar(SubCategoria2 obj, out string Mensaje)
        {
            return objcd_SubCategoria2.Eliminar(obj, out Mensaje);

        }

        public byte[] ObtenerFotoSubCategoria2(int idSubCategoria, out bool obtenido)
        {
            return objcd_SubCategoria2.ObtenerFotoSubCategoria2(idSubCategoria, out obtenido);
        }

        public bool ActualizarFotoSubCategoria2(int idSubCategoria, byte[] fotosubcategoria, out string mensaje)
        {
            return objcd_SubCategoria2.ActualizarFotoSubCategoria2(idSubCategoria, fotosubcategoria, out mensaje);
        }

    }
}
