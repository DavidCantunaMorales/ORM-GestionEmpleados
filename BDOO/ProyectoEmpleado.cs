using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOO
{
    public class ProyectoEmpleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProyectoEmp {  get; set; }

        // CLASE QUE PARTE LA RELACION DE MUCHOS A MUCHOS
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

        public int IdProyecto { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
