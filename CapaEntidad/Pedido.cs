using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Usuario oUsuario { get; set; }
        public string NumeroDocumento { get; set; }

        public List<DetallePedido> oDetallePedido { get; set; }
        public string FechaRegistro { get; set; }
        public string HoraPedido { get; set; }
        public string Estado { get; set; }
    }
}
