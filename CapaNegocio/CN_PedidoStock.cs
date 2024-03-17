using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PedidoStock
    {
        private CD_PedidoStock objcd_PedidoStock = new CD_PedidoStock();

        public List<PedidoStock> ObtenerProductosConCantidad()
        {
            return objcd_PedidoStock.ObtenerProductosConCantidad();
        }

        public bool RegistrarEscaneoProducto(PedidoStock escaneo)
        {
            return objcd_PedidoStock.RegistrarPedidoStock(escaneo);
        }
    }
}
