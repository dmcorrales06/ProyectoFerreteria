using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Código es Obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Clave es Obligatorio")]
        public string Clave { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Rol es Obligatorio")]
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
