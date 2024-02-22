using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Pedido
    {
        private CD_Pedido objcd_compra = new CD_Pedido();

        public int ObtenerCorrelativo()
        {
            return objcd_compra.ObtenerCorrelativo();
        }
        public bool Registrar(Pedido obj, DataTable DetallePedido, out string Mensaje)
        {
            return objcd_compra.Registrar(obj, DetallePedido, out Mensaje);
        }
        public Pedido ObtenerPedido(string numero)
        {
            Pedido oPedido = objcd_compra.ObtenerPedido(numero);

            if (oPedido.IdPedido != 0)
            {
                List<DetallePedido> oDetallePedido = objcd_compra.ObtenerDetallePedido(oPedido.IdPedido);

                oPedido.oDetallePedido = oDetallePedido;
            }
            return oPedido;

        }
    }
}
