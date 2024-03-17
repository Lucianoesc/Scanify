using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcd_negocio = new CD_Negocio();

        public Negocio ObtenerDatos()
        {
            return objcd_negocio.ObtenerDatos();
        }
        public bool Guardar(Negocio obj, out string Mensaje)
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
                return objcd_negocio.Guardar(obj, out Mensaje);
            }


        }

        public byte[] ObtenerFoto(out bool obtenido)
        {
            return objcd_negocio.ObtenerFoto(out obtenido);
        }
        public bool ActualizarFoto(byte[] imagen,out string mensaje)
        {
            return objcd_negocio.ActualizarFoto(imagen, out mensaje);
        }

    }
}
