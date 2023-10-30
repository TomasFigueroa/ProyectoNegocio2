using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bdata.Data.Entity
{
    //[Index(nameof(codigo_cuotas), Name = "Cuota_Codigo_cuotas_UQ", IsUnique = true)]
    public class Cuota
    {
        public int Id { get; set; }
     

        [Required(ErrorMessage = "El total es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres el total")]
        public string total { get; set; }

        [Required(ErrorMessage = "El numero de cuotas es Obligatorio")]
        [MaxLength(4, ErrorMessage = "Solo se aceptan hasta 4 caracteres en el numero de cuotas")]
        public string Numero_cuotas { get; set; }

        public int Idventa { get; set; }
        public int dnipersona { get; set; }

    }
}
