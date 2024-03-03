using BDOO;
using BDOO.DTOClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaGestionEmpleados.DTOControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantidadDepartamentoController : ControllerBase
    {
        private BDContext _context;

        public CantidadDepartamentoController(BDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<CantidadDepartamento>> GetCantidadDepartamento()
        {
            var listEmpleado = _context.Empleados.ToList();
            var listDepartamento = _context.Departamentos.ToList();


            var query =
                from departamento in listDepartamento
                join empleado in listEmpleado on new { departamento.IdDep }
                    equals
                new { empleado.IdDep }
                group departamento by departamento.NombreDep into departamentoCantidad
                select new
                {
                    CDDepartamento = departamentoCantidad.Key, // Contiene el valor por el cual se agruparon los elementos 
                    CDCantidad = departamentoCantidad.Count() // Devuelve la cantidad de elementos en cada grupo
                };

            /*
             var query = listDepartamento
                .Join(listEmpleado,
                      departamento => departamento.IdDep,
                      empleado => empleado.IdDep,
                      (departamento, empleado) => new { Departamento = departamento, Empleado = empleado })
                .GroupBy(x => x.Departamento.NombreDep)
                .Select(g => new
                {
                    CDDepartamento = g.Key,
                    CDCantidad = g.Count()
                });
            */
            List<CantidadDepartamento> empleadoDepartamento = new List<CantidadDepartamento>();
            CantidadDepartamento oEmpleadoDepartamento;

            foreach (var empDep in query)
            {
                oEmpleadoDepartamento = new CantidadDepartamento();
                oEmpleadoDepartamento.NombreDepartamento = empDep.CDDepartamento;
                oEmpleadoDepartamento.CantidadEmpleados = empDep.CDCantidad;

                empleadoDepartamento.Add(oEmpleadoDepartamento);
            }

            return Task.Run(() => empleadoDepartamento);
        }

    }
}
