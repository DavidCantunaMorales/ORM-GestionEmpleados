using BDOO;
using BDOO.DTOClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionEmpleados.DTOControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoDepartamentoController : ControllerBase
    {
        private BDContext _context;

        public EmpleadoDepartamentoController(BDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<EmpleadoDepartamento>> GetEmpleadoDepartamento(string nDepartamento)
        {
            var listEmpleado = _context.Empleados.ToList();
            var listDepartamento = _context.Departamentos.ToList();


            var query =
                from empleado in listEmpleado
                join departamento in listDepartamento on new { empleado.IdDep }
                    equals
                new { departamento.IdDep }
                where departamento.NombreDep == nDepartamento
                select new
                {
                    EDNombre = empleado.Nombre,
                    EDApellido = empleado.Apellido,
                    EDepartamento = departamento.NombreDep
                };

            /*
            var query = listEmpleado
                .Join(listDepartamento,
                      empleado => empleado.IdDep,
                      departamento => departamento.IdDep,
                      (empleado, departamento) => new { Empleado = empleado, Departamento = departamento })
                .Where(x => x.Departamento.NombreDep == nDepartamento)
                .Select(x => new
                {
                    EDNombre = x.Empleado.Nombre,
                    EDApellido = x.Empleado.Apellido,
                    EDepartamento = x.Departamento.NombreDep
                });
            */
            List<EmpleadoDepartamento> empleadoDepartamento = new List<EmpleadoDepartamento>();
            EmpleadoDepartamento oEmpleadoDepartamento;

            foreach (var empDep in query)
            {
                oEmpleadoDepartamento = new EmpleadoDepartamento();
                oEmpleadoDepartamento.NombreEmpleado = empDep.EDNombre;
                oEmpleadoDepartamento.ApellidoEmpleado = empDep.EDApellido;
                oEmpleadoDepartamento.NombreDepartamento = empDep.EDepartamento;

                empleadoDepartamento.Add(oEmpleadoDepartamento);
            }

            return Task.Run(() => empleadoDepartamento);
        }
    }
}
