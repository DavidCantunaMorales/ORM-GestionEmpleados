using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class SupervisorService
    {
        private readonly BDContext _context;

        public SupervisorService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supervisor>> GetSupervisores()
        {
            return await _context.Supervisores.ToListAsync();
        }

        public async Task<Supervisor> GetSupervisor(int id)
        {
            return await _context.Supervisores.FindAsync(id);
        }

        public async Task<Supervisor> CreateSupervisor(Supervisor newSupervisor)
        {
            _context.Supervisores.Add(newSupervisor);
            await _context.SaveChangesAsync();
            return newSupervisor;
        }

        public async Task UpdateSupervisor(int id, Supervisor supervisor)
        {
            var existSupervisor = await GetSupervisor(id);

            if (existSupervisor != null)
            {
                existSupervisor.Nombre = supervisor.Nombre;
                existSupervisor.Apellido = supervisor.Apellido;
                existSupervisor.Direccion = supervisor.Direccion;
                existSupervisor.Telefono = supervisor.Telefono;
                existSupervisor.Correo = supervisor.Correo;
                existSupervisor.IdDep = supervisor.IdDep;
                existSupervisor.IdHorario = supervisor.IdHorario;
                existSupervisor.IdProyecto = supervisor.IdProyecto;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSupervisor(int id)
        {
            var supervisorDelete = await GetSupervisor(id);

            if (supervisorDelete != null)
            {
                _context.Supervisores.Remove(supervisorDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
