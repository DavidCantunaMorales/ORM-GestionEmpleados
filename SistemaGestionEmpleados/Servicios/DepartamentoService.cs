using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class DepartamentoService
    {
        private readonly BDContext _context;

        public DepartamentoService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamento(int id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task<Departamento> CreateDepartamento(Departamento newDepartamento)
        {
            _context.Departamentos.Add(newDepartamento);
            await _context.SaveChangesAsync();
            return newDepartamento;
        }

        public async Task UpdateDepartamento(int id, Departamento departamento)
        {
            var existDepartamento = await GetDepartamento(id);

            if (existDepartamento != null) {
                existDepartamento.NombreDep = departamento.NombreDep;
                existDepartamento.DescripcionDep = departamento.DescripcionDep;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartamento(int id)
        {
            var departamentoDelete = await GetDepartamento(id);

            if (departamentoDelete != null) {
                _context.Departamentos.Remove(departamentoDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
