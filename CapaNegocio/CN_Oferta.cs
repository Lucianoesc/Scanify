using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Oferta
    {
        private CD_Oferta objcd_Oferta = new CD_Oferta();

        public List<Oferta> Listar()
        {
            return objcd_Oferta.ListarOfertas();
        }

        public int Registrar(Oferta obj, byte[] imagen, byte[] pantallaprincipal, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreOferta == "")
            {
                Mensaje += "Es necesario el nombre del Oferta\n";
            }
            if (obj.Descuento.ToString() == "")
            {
                Mensaje += "Es necesario el descuento del Oferta\n";
            }
            if (obj.FechaInicio.ToString() == "")
            {
                Mensaje += "Es necesario la fechaInicio de la Oferta\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Oferta.Registrar(obj, imagen, pantallaprincipal, out Mensaje);
            }



        }

        public bool Editar(Oferta obj, byte[] nuevaImagen, byte[] pantallaprincipal, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreOferta == "")
            {
                Mensaje += "Es necesario el Nombre del Oferta\n";
            }
            if (obj.Descuento.ToString() == "")
            {
                Mensaje += "Es necesario el Descuento del Oferta\n";
            }
            if (obj.FechaFin.ToString() == "")
            {
                Mensaje += "Es necesario la fecha de inicio de la Oferta\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                if (nuevaImagen != null)
                {
                    bool respuestaImagen = ActualizarFoto(obj.IdOferta, nuevaImagen, pantallaprincipal, out Mensaje);

                    if (!respuestaImagen)
                    {
                        Mensaje = "No se pudo asociar la nueva imagen a la Oferta";
                        return false;
                    }
                }

                return objcd_Oferta.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Oferta obj, out string Mensaje)
        {
            return objcd_Oferta.Eliminar(obj, out Mensaje);
        }

        public byte[] ObtenerFoto(int idOferta, out bool obtenido)
        {
            return objcd_Oferta.ObtenerFoto(idOferta, out obtenido);
        }
        public byte[] ObtenerFotoPrincipal(int idOferta, out bool obtenido2)
        {
            return objcd_Oferta.ObtenerFotoPrincipal(idOferta, out obtenido2);
        }
        public bool ActualizarFoto(int idOferta, byte[] imagen, byte[] pantallaprincipal, out string mensaje)
        {
            return objcd_Oferta.ActualizarFoto(idOferta, imagen, pantallaprincipal, out mensaje);
        }

        public List<Producto> ListarProductos_Oferta()
        {
            return objcd_Oferta.ListarProductos_Oferta();
        }
        public bool AsociarProductosAOferta(int idOferta, List<int> productosSeleccionados, out string mensaje)
        {
            // Validaciones de negocios, si es necesario

            // Llamar a la Capa de Datos para asociar productos a la oferta
            return objcd_Oferta.AsociarProductosAOferta(idOferta, productosSeleccionados, out mensaje);
        }
        public bool DesasociarProductosDeOferta(int idOferta, List<int> productosDesasociar, out string mensaje)
        {
            // Validaciones de negocios, si es necesario

            // Llamar a la Capa de Datos para desasociar productos de la oferta
            return objcd_Oferta.DesasociarProductosDeOferta(idOferta, productosDesasociar, out mensaje);
        }
        public List<Producto> ListarProductosPorOferta(int idOferta)
        {
            return objcd_Oferta.ListarProductosPorOferta(idOferta);
        }


    }
}
