using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class ProyectoService
    {
        private readonly BDContext _context;

        public ProyectoService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proyecto>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        public async Task<Proyecto> GetProyecto(int id)
        {
            return await _context.Proyectos.FindAsync(id);
        }

        public async Task<Proyecto> CreateProyecto(Proyecto newProyecto)
        {
            _context.Proyectos.Add(newProyecto);
            await _context.SaveChangesAsync();
            return newProyecto;
        }

        public async Task UpdateProyecto(int id, Proyecto proyecto)
        {
            var existProyecto = await GetProyecto(id);

            if (existProyecto != null)
            {
                existProyecto.NombreProyecto = proyecto.NombreProyecto;
                existProyecto.DescripcionProyecto = proyecto.DescripcionProyecto;
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
