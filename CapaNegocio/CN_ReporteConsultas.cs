using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_ReporteConsultas
    {
        private CD_ReporteConsultas objCD_Reporte = new CD_ReporteConsultas();

        public List<ReporteConsultas> Consultas(string fechaInicio, string fechaFin, int idProducto)
        {
            return objCD_Reporte.Consultas(fechaInicio, fechaFin, idProducto);
        }
    }
}
