using BDOO;
using BDOO.DTOClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionEmpleados.DTOControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosEmpleadosController : ControllerBase
    {
        private BDContext _context;

        public ProyectosEmpleadosController(BDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<ProyectosEmpleado>> GetProyectosEmpleado(string nNombre, string nApellido)
        {
            var listEmpleado = _context.Empleados.ToList();
            var listProyecto = _context.Proyectos.ToList();
            var listProyectoEmpleado = _context.ProyectosEmpleados.ToList();


            var query =
                from proyectoEmpleado in listProyectoEmpleado
                join proyecto in listProyecto on proyectoEmpleado.IdProyecto equals proyecto.IdProyecto
                join empleado in listEmpleado on proyectoEmpleado.IdEmpleado equals empleado.IdEmp
                where empleado.Nombre == nNombre && empleado.Apellido == nApellido
                select new
                {
                    PEProyecto = proyecto.NombreProyecto
                };

            /*
            var query = listProyectoEmpleado
                .Join(listProyecto,
                      proyectoEmpleado => proyectoEmpleado.IdProyecto,
                      proyecto => proyecto.IdProyecto,
                      (proyectoEmpleado, proyecto) => new { ProyectoEmpleado = proyectoEmpleado, Proyecto = proyecto })
                .Join(listEmpleado,
                      x => x.ProyectoEmpleado.IdEmpleado,
                      empleado => empleado.IdEmp,
                      (x, empleado) => new { x.ProyectoEmpleado, x.Proyecto, Empleado = empleado })
                .Where(x => x.Empleado.Nombre == nNombre && x.Empleado.Apellido == nApellido)
                .Select(x => new
                {
                    PEProyecto = x.Proyecto.NombreProyecto
                });

            */
            List<ProyectosEmpleado> empleadoDepartamento = new List<ProyectosEmpleado>();
            ProyectosEmpleado oEmpleadoDepartamento;

            foreach (var empDep in query)
            {
                oEmpleadoDepartamento = new ProyectosEmpleado();
                oEmpleadoDepartamento.NombreDepartamento = empDep.PEProyecto;

                empleadoDepartamento.Add(oEmpleadoDepartamento);
            }

            return Task.Run(() => empleadoDepartamento);
        }
    }
}
