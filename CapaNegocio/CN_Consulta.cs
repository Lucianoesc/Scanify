using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Consulta
    {
        private CD_Consulta objcd_consulta = new CD_Consulta();

        public bool RegistrarEscaneoProducto(Consulta escaneo)
        {
            return objcd_consulta.RegistrarEscaneo(escaneo);
        }
        public List<Consulta> ObtenerProductosMasConsultadosPorSemana()
        {
            return objcd_consulta.ObtenerProductosMasConsultadosPorSemana();
        }
    }
}
