using BDOO;
using BDOO.DTOClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionEmpleados.DTOControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoProyectoController : ControllerBase
    {
        private BDContext _context;

        public EmpleadoProyectoController(BDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<EmpleadosProyecto>> GetEmpleadosProyecto(string NombreProyecto)
        {
            var listEmpleado = _context.Empleados.ToList();
            var listProyectoEmpleado = _context.ProyectosEmpleados.ToList();
            var listProyecto = _context.Proyectos.ToList();

            var query =
                from empleado in listEmpleado
                join proyectoEmpleado in listProyectoEmpleado on empleado.IdEmp
                    equals
                proyectoEmpleado.IdEmpleado
                join proyecto in listProyecto on proyectoEmpleado.IdProyecto
                    equals
                proyecto.IdProyecto
                where proyecto.NombreProyecto == NombreProyecto
                select new
                {
                    EPNombre = empleado.Nombre,
                    EPApellido = empleado.Apellido
                };

            /*
            var query = listEmpleado
                .Join(listProyectoEmpleado,
                      empleado => empleado.IdEmp,
                      proyectoEmpleado => proyectoEmpleado.IdEmpleado,
                      (empleado, proyectoEmpleado) => new { Empleado = empleado, ProyectoEmpleado = proyectoEmpleado })
                .Join(listProyecto,
                      x => x.ProyectoEmpleado.IdProyecto,
                      proyecto => proyecto.IdProyecto,
                      (x, proyecto) => new { x.Empleado, Proyecto = proyecto })
                .Where(x => x.Proyecto.NombreProyecto == NombreProyecto)
                .Select(x => new
                {
                    EPNombre = x.Empleado.Nombre,
                    EPApellido = x.Empleado.Apellido
                });
            */

            List<EmpleadosProyecto> empleadoDepartamento = new List<EmpleadosProyecto>();
            EmpleadosProyecto oEmpleadoDepartamento;

            foreach (var empDep in query)
            {
                oEmpleadoDepartamento = new EmpleadosProyecto();
                oEmpleadoDepartamento.NombreEmpleado = empDep.EPNombre;
                oEmpleadoDepartamento.ApellidoEmpleado = empDep.EPApellido;

                empleadoDepartamento.Add(oEmpleadoDepartamento);
            }

            return Task.Run(() => empleadoDepartamento);
        }
    }
}
