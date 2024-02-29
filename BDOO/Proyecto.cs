using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOO
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProyecto { get; set; }
        public string? NombreProyecto { get; set; }
        public string? DescripcionProyecto { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }

        // RELACION DE MUCHOS A MUCHOS
        public virtual ICollection<ProyectoEmpleado> ProyectoEmpleados { get; set; }
    }
}
