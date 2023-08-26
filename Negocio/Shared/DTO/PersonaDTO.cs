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
        
        public int DNI { get; set; }

        public string Nombre { get; set; } 

        public int Telefono { get; set; }

      
        public string Email { get; set; } = "";

        public int Direccion { get; set; }

    }
}
