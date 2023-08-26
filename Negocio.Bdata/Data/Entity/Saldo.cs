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
    [Index(nameof(Idsaldo), Name = "Cuenta_Idcuenta_UQ", IsUnique = true)]
    public class Saldo
    {
        public int id { get; set; }
    
        [Required(ErrorMessage = "El Numero Idsaldo es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el Numero de idsaldo")]
        public int Idsaldo { get; set; }
        [Required(ErrorMessage = "El Numero de Saldo a favor es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en saldo a favor")]
        public int SaldoF { get; set; }

        [Required(ErrorMessage = "El Numero de Saldo restante es Obligatorio ")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en saldo Restante")]
        public int SaldoR { get; set; }


    }
}
