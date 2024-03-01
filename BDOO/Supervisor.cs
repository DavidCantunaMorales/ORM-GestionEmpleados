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
    public class Supervisor : Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSup { get; set; }

        // ATRIBUTOS PARA LOS ID DE CLASE FORANEAS
        public int IdDep { get; set; }
        public int IdHorario { get; set; }
        public int IdProyecto { get; set; }

        // IMPLEMENTACION DE CLAVES FORANEAS
        [ForeignKey("IdProyecto")]
        [JsonIgnore]
        public virtual Proyecto? Proyecto { get; set; }

        [ForeignKey("IdDep")]
        [JsonIgnore]
        public virtual Departamento? Departamento { get; set; }

        [ForeignKey("IdHorario")]
        [JsonIgnore]
        public virtual Horario? Horario { get; set; }

    }
}
