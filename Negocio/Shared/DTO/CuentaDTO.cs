using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Shared.DTO
{
    public class CuentaDTO
    {
        public int NumeroCuenta { get; set; }
        public int SaldoTotal { get; set; }
        public int Cuotas { get; set; }
    }
}
