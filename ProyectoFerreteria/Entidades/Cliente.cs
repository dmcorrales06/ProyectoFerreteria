using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Cliente
    {
        [Required(ErrorMessage = "La Identidad es Obligatorio")]
        public string Identidad { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string NombreCliente { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string Telefono { get; set; }



    }
}
