using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BDOO
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDep { get; set; }
        [Required(ErrorMessage = "El nombre del departamento no puede repetirse.")]
        public string? NombreDep { get; set; }
        public string? DescripcionDep { get; set; }

        [JsonIgnore]
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
        [JsonIgnore]
        public virtual ICollection<Supervisor> Supervisores { get; set; } = new List<Supervisor>();
    }
}
