using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Shared.DTO
{
    public class PersonaDTO
    {
        
        public string DNI { get; set; }

        public string Nombre { get; set; } 

        public string Telefono { get; set; }

      
        public string Email { get; set; } = "";

        public string Direccion { get; set; }

    }
}
