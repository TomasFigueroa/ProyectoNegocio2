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
    [Index(nameof(Codigo_Cuenta), Name = "Venta_Codigo_Cuenta_UQ", IsUnique = true)]
    public class Venta
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El Codigo cuenta es Obligatorio")]
        [MaxLength(4, ErrorMessage = "Solo se aceptan hasta 4 caracteres en el Codigo cuenta")]
        public string Codigo_Cuenta { get; set; }

        [Required(ErrorMessage = "La descripcion es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en la descripcion")]
        public string descripcion { get; set; }

        public int Idpersona { get; set; }

        public List<Cuota> cuotas { get; set; } = new List<Cuota>();



    }
}
