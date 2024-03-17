using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PedidoStock
    {
        public int IdPedidoStock { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaPedidoStock { get; set; }
        public string Producto { get; set; }
        public int Pedidos { get; set; }
    }
}
