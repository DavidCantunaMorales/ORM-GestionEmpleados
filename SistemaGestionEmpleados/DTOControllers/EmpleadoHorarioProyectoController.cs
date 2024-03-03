using BDOO;
using BDOO.DTOClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionEmpleados.DTOControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoHorarioProyectoController : ControllerBase
    {
        private BDContext _context;

        public EmpleadoHorarioProyectoController(BDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<EmpleadoHorarioProyecto>> GetEmpleadoHorarioProyecto(string nProyecto, string hEntrada, string hSalida)
        {
            var listEmpleado = _context.Empleados.ToList();
            var listHorario = _context.Horarios.ToList();
            var listDepartamento = _context.Departamentos.ToList();
            var listProyecto = _context.Proyectos.ToList();
            var listProyectoEmpleado = _context.ProyectosEmpleados.ToList();


            var query =
                from empleado in listEmpleado
                join horario in listHorario on empleado.IdHorario equals horario.IdHorario
                join proyectoEmpleado in listProyectoEmpleado on empleado.IdEmp equals proyectoEmpleado.IdEmpleado
                join proyecto in listProyecto on proyectoEmpleado.IdProyecto equals proyecto.IdProyecto
                join departamento in listDepartamento on empleado.IdDep equals departamento.IdDep
                where proyecto.NombreProyecto == nProyecto &&
                      horario.HoraEntrada == hEntrada &&
                      horario.HoraSalida == hSalida
                select new
                {
                    EHPNombreEmpleado = empleado.Nombre,
                    EHPApellidoEmpleado = empleado.Apellido,
                    EHPNombreDepartamento = departamento.NombreDep
                };

            /*
        var query = listEmpleado
            .Join(listHorario,
                  empleado => empleado.IdHorario,
                  horario => horario.IdHorario,
                  (empleado, horario) => new { Empleado = empleado, Horario = horario })
            .Join(listProyectoEmpleado,
                  x => x.Empleado.IdEmp,
                  proyectoEmpleado => proyectoEmpleado.IdEmpleado,
                  (x, proyectoEmpleado) => new { x.Empleado, x.Horario, ProyectoEmpleado = proyectoEmpleado })
            .Join(listProyecto,
                  x => x.ProyectoEmpleado.IdProyecto,
                  proyecto => proyecto.IdProyecto,
                  (x, proyecto) => new { x.Empleado, x.Horario, x.ProyectoEmpleado, Proyecto = proyecto })
            .Join(listDepartamento,
                  x => x.Empleado.IdDep,
                  departamento => departamento.IdDep,
                  (x, departamento) => new { x.Empleado, x.Horario, x.ProyectoEmpleado, x.Proyecto, Departamento = departamento })
            .Where(x => x.Proyecto.NombreProyecto == nProyecto &&
                        x.Horario.HoraEntrada == hEntrada &&
                        x.Horario.HoraSalida == hSalida)
            .Select(x => new
            {
                EHPNombreEmpleado = x.Empleado.Nombre,
                EHPApellidoEmpleado = x.Empleado.Apellido,
                EHPNombreDepartamento = x.Departamento.NombreDep
            });
            */
            List<EmpleadoHorarioProyecto> empleadoDepartamento = new List<EmpleadoHorarioProyecto>();
            EmpleadoHorarioProyecto oEmpleadoDepartamento;

            foreach (var empDep in query)
            {
                oEmpleadoDepartamento = new EmpleadoHorarioProyecto();
                oEmpleadoDepartamento.NombreEmpleado = empDep.EHPNombreEmpleado;
                oEmpleadoDepartamento.ApellidoEmpleado = empDep.EHPApellidoEmpleado;
                oEmpleadoDepartamento.Departamento = empDep.EHPNombreDepartamento;

                empleadoDepartamento.Add(oEmpleadoDepartamento);
            }

            return Task.Run(() => empleadoDepartamento);
        }

    }
}
