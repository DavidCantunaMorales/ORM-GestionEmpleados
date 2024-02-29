using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOO
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmp { get; set; }
        public string? NombreEmp { get; set; }
        public string? ApellidoEmp { get; set; }
        public string? DireccionEmp { get; set; }
        public string? TelefonoEmp { get; set; }
        public string? CorreoEmp { get; set; }

        // ATRIBUTOS PARA LOS ID DE CLASE FORANEAS
        public int IdCargo { get; set; }
        public int IdDep { get; set; }
        public int IdHorario { get; set; }

        // IMPLEMENTACION DE CLAVES FORANEAS
        [ForeignKey("IdCargo")]
        public virtual Cargo? Cargo { get; set; }

        [ForeignKey("IdDep")]
        public virtual Departamento? Departamento { get; set; }

        [ForeignKey("IdHorario")]
        public virtual Horario? Horario { get; set; }

        // RELACION DE MUCHOS A MUCHOS
        public virtual ICollection<ProyectoEmpleado> ProyectoEmpleados { get; set; }
    }
}
