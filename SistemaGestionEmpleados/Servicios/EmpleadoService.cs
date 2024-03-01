using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class EmpleadoService
    {
        private readonly BDContext _context;

        public EmpleadoService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado> GetEmpleado(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task<Empleado> CreateEmpleado(Empleado newEmpleado)
        {
            _context.Empleados.Add(newEmpleado);
            await _context.SaveChangesAsync();
            return newEmpleado;
        }

        public async Task UpdateEmpleado(int id, Empleado empleado)
        {
            var existEmpleado = await GetEmpleado(id);

            if (existEmpleado != null)
            {
                existEmpleado.NombreEmp = empleado.NombreEmp;
                existEmpleado.ApellidoEmp = empleado.ApellidoEmp;
                existEmpleado.DireccionEmp = empleado.DireccionEmp;
                existEmpleado.TelefonoEmp = empleado.TelefonoEmp;
                existEmpleado.CorreoEmp = empleado.CorreoEmp;
                existEmpleado.IdCargo = empleado.IdCargo;
                existEmpleado.IdDep = empleado.IdDep;
                existEmpleado.IdHorario = empleado.IdHorario;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmpleado(int id)
        {
            var empleadoDelete = await GetEmpleado(id);

            if (empleadoDelete != null)
            {
                _context.Empleados.Remove(empleadoDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
