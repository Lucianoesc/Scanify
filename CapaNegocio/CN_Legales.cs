using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Legales
    {
        private CD_Legales objcd_legales = new CD_Legales();

        public Legales ObtenerDatos()
        {
            return objcd_legales.ObtenerDatos();
        }
        public bool Guardar(Legales obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre de la empresa\n";
            }
            if (obj.CUIT == "")
            {
                Mensaje += "Es necesario el numero del cuit de la empresa\n";
            }
            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario la direccion de la empresa\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_legales.Guardar(obj, out Mensaje);
            }


        }

        public byte[] ObtenerFoto(out bool obtenido)
        {
            return objcd_legales.ObtenerFoto(out obtenido);
        }
        public bool ActualizarFoto(byte[] imagen,out string mensaje)
        {
            return objcd_legales.ActualizarFoto(imagen, out mensaje);
        }

    }
}
