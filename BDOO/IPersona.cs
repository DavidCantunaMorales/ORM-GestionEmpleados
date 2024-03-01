using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOO
{
    public interface IPersona
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        string Correo { get; set; }
    }
}
