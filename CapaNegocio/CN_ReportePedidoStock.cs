using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_ReportePedidoStock
    {
        private CD_ReportePedidoStock objCD_Reporte = new CD_ReportePedidoStock();

        public List<ReportePedidoStock> PedidoStocks(string fechaInicio, string fechaFin, int idProducto)
        {
            return objCD_Reporte.PedidoStocks(fechaInicio, fechaFin, idProducto);
        }
    }
}
