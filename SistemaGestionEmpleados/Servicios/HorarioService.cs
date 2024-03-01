using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class HorarioService
    {
        private readonly BDContext _context;

        public HorarioService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Horario>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }

        public async Task<Horario> GetHorario(int id)
        {
            return await _context.Horarios.FindAsync(id);
        }

        public async Task<Horario> CreateHorario(Horario newHorario)
        {
            _context.Horarios.Add(newHorario);
            await _context.SaveChangesAsync();
            return newHorario;
        }

        public async Task UpdateHorario(int id, Horario horario)
        {
            var existHprario = await GetHorario(id);

            if (existHprario != null)
            {
                existHprario.HoraEntrada = horario.HoraEntrada;
                existHprario.HoraSalida = horario.HoraSalida;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmpleado(int id)
        {
            var horarioDelete = await GetHorario(id);

            if (horarioDelete != null)
            {
                _context.Horarios.Remove(horarioDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
