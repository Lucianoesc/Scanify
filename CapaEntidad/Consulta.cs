using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaEscaneo { get; set; }

        public string Producto { get; set; }
        public int Consultas { get; set; }
    }
}
