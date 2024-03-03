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
    public class Horario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario { get; set; }
        public string? HoraEntrada { get; set; }
        public string? HoraSalida { get; set; }
        [JsonIgnore]
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
        [JsonIgnore]
        public virtual ICollection<Supervisor> Supervisores { get; set; } = new List<Supervisor>();
    }
}
