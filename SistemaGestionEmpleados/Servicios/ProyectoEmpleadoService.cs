using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class ProyectoEmpleadoService
    {
        private readonly BDContext _context;

        public ProyectoEmpleadoService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProyectoEmpleado>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        public async Task<ProyectoEmpleado> GetProyecto(int id)
        {
            return await _context.Proyectos.FindAsync(id);
        }

        public async Task<ProyectoEmpleado> CreateProyecto(Proyecto newProyecto)
        {
            _context.Proyectos.Add(newProyecto);
            await _context.SaveChangesAsync();
            return newProyecto;
        }

        public async Task UpdateProyecto(int id, Proyecto c)
        {
            var existProyecto = await GetProyecto(id);

            if (existProyecto != null)
            {
                existProyecto.NombreProyecto = existProyecto.NombreProyecto;
                existProyecto.DescripcionProyecto = existProyecto.DescripcionProyecto;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProyecto(int id)
        {
            var proyectoDelete = await GetProyecto(id);

            if (proyectoDelete != null)
            {
                _context.Proyectos.Remove(proyectoDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
