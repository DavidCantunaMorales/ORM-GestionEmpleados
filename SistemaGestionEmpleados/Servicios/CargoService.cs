using BDOO;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Servicios
{
    public class CargoService
    {
        private readonly BDContext _context;

        public CargoService(BDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            return await _context.Cargos.ToListAsync();
        }

        public async Task<Cargo> GetCargo(int id)
        {
            return await _context.Cargos.FindAsync(id);
        }

        public async Task<Cargo> CreateCargo(Cargo newCargo)
        {
            _context.Cargos.Add(newCargo);
            await _context.SaveChangesAsync();
            return newCargo;
        }

        public async Task UpdateCargo(int id, Cargo cargo)
        {
            var existCargo = await GetCargo(id);

            if (existCargo != null) {
                existCargo.NombreCargo = cargo.NombreCargo;
                existCargo.DescripcionCargo = cargo.DescripcionCargo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCargo(int id)
        {
            var cargoDelete = await GetCargo(id);

            if (cargoDelete != null) {
                _context.Cargos.Remove(cargoDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
