using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bdata.Data.Entity
{
    [Index(nameof(NumeroCuenta), Name = "Cuenta_NumeroCuenta_UQ", IsUnique = true)]
    public class Cuenta
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El Numero cuenta es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el Numero de cuenta")]
        public int NumeroCuenta { get; set;}

        [Required(ErrorMessage = "El Saldo es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el saldo")]
        public int SaldoTotal { get; set; }

        [Required(ErrorMessage = "El Saldo es Obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el cuotas")]
        public int Cuotas { get; set; }


    }
}
