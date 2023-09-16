using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Shared.DTO
{
    public class VentaDTO
    {
        public string codigo_venta { get; set; }
        public string descripcion { get; set; }

        public int idpersona { get; set; }
    }
}
