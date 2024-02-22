using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Bitacora
    {
        public void InsertarBitacora(string usuario, string idusuario, string evento, string detalle, string origen)
        {
            CD_Bitacora cdBitacora = new CD_Bitacora();
            cdBitacora.InsertarBitacora(usuario, idusuario, evento, detalle, origen);
        }

        public List<Bitacora> ListarBitacora()
        {
            CD_Bitacora cdBitacora = new CD_Bitacora();
            return cdBitacora.ListarBitacora();
        }
    }
}
