using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BDOO
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProyecto { get; set; }
        public string? NombreProyecto { get; set; }
        public string? DescripcionProyecto { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaFin { get; set; }

        // RELACION DE MUCHOS A MUCHOS
        [JsonIgnore]
        public virtual ICollection<ProyectoEmpleado>? ProyectoEmpleados { get; set; }
    }
}
