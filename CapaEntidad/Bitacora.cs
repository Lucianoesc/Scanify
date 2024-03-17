using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Evento { get; set; }
        public string Detalle { get; set; }
        public string Origen { get; set; }
    }
}
