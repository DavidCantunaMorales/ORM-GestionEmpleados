﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BDOO
{
    public class Empleado: Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmp { get; set; }

        // ATRIBUTOS PARA LOS ID DE CLASE FORANEAS
        public int IdDep { get; set; }
        public int IdHorario { get; set; }

        // IMPLEMENTACION DE CLAVES FORANEAS

        [ForeignKey("IdDep")]
        [JsonIgnore]
        public virtual Departamento? Departamento { get; set; }

        [ForeignKey("IdHorario")]
        [JsonIgnore]
        public virtual Horario? Horario { get; set; }

        // RELACION DE MUCHOS A MUCHOS
        [JsonIgnore]
        public virtual ICollection<ProyectoEmpleado>? ProyectoEmpleados { get; set; }
    }
}
