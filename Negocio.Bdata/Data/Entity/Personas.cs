using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Bdata.Data.Entity
{
    [Index(nameof(DNI), Name = "Persona_DNI_UQ", IsUnique = true)]
    public class Personas
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "El Código de la Especialidad es Obligatorio")]
        [MaxLength(8, ErrorMessage = "Solo se aceptan hasta 8 caracteres en DNI")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "El Código de la Especialidad es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el Nombre")]
        public string Nombre { get; set; } = "";


        [Required(ErrorMessage = "El Código de la Especialidad es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el Telefono")]

        public int Telefono { get; set; }

        [Required(ErrorMessage = "El Código de la Especialidad es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el Email")]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "El Código de la Especialidad es Obligatorio")]
        [MaxLength(5, ErrorMessage = "Solo se aceptan hasta 5 caracteres en Direccion")]
        public int Direccion { get; set; }

       

    }

    
}
