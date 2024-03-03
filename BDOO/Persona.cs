using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOO
{
    public class Persona : IPersona
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        [Required(ErrorMessage = "El telefono no puede repetirse.")]
        public required string Telefono { get; set; }
        [Required(ErrorMessage = "El correo no puede repetirse.")]
        public required string Correo { get; set; }
    }
}
