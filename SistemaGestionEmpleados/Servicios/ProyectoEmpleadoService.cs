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

        public async Task<IEnumerable<ProyectoEmpleado>> GetProyectoEmpleados()
        {
            return await _context.ProyectosEmpleados.ToListAsync();
        }

        public async Task<ProyectoEmpleado> GetProyectoEmpleado(int idProyectoEmp)
        {
            return await _context.ProyectosEmpleados.FindAsync(idProyectoEmp);
        }


        public async Task<ProyectoEmpleado> CreateProyecto(ProyectoEmpleado newProyectoEmpleado)
        {
            _context.ProyectosEmpleados.Add(newProyectoEmpleado);
            await _context.SaveChangesAsync();
            return newProyectoEmpleado;
        }

        public async Task UpdateProyectoEmpleado(int id, ProyectoEmpleado proyectoempleado)
        {
            var existProyectoEmpleado = await GetProyectoEmpleado(id);

            if (existProyectoEmpleado != null)
            {
                existProyectoEmpleado.IdEmpleado = proyectoempleado.IdEmpleado;
                existProyectoEmpleado.IdProyecto = proyectoempleado.IdProyecto;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProyectoEmpleado(int id)
        {
            var proyectoEmpleadoDelete = await GetProyectoEmpleado(id);

            if (proyectoEmpleadoDelete != null)
            {
                _context.ProyectosEmpleados.Remove(proyectoEmpleadoDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
