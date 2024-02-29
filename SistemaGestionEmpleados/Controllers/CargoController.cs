using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private BDContext _context;

        public CargoController(BDContext context)
        {
            _context = context;
        }

        // OBTENER TODOS LOS CARGOS
        [HttpGet]
        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _context.Cargos.ToListAsync();
        }

        // OBTENER UN CARGO
        [HttpGet("getCargo/{id}")]
        public async Task<ActionResult<Cargo>> GetById(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo is null) {
                return AccountNotFound(id);
            }
            return cargo;
        }

        // CREAR UN NUEVO CARGO
        [HttpPost("addCargo")]
        public async Task<ActionResult<Cargo>> Create(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            var newCargo = await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = cargo.IdCargo }, cargo);
        }

        // ACTUALIZAR UN CARGO
        [HttpPut("updateClient/{id}")]
        public async Task<ActionResult> Update(int id, Cargo cargo)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != cargo.IdCargo) {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({cargo.IdCargo}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL CARGO A ACTUALIZAR
            var cargoUpdate = await _context.Cargos.FindAsync(id);

            // VERIFICAR SI SE ENCUENTRA EL CARGO
            if (cargoUpdate is not null) {
                cargoUpdate.NombreCargo = cargo.NombreCargo;
                cargoUpdate.DescripcionCargo = cargo.DescripcionCargo;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else{
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN CARGO
        [HttpDelete("deleteClient/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cargoDelete = await _context.Cargos.FindAsync(id);

            if (cargoDelete is not null) {
                _context.Cargos.Remove(cargoDelete);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else {
                return AccountNotFound(id);
            }
        }

        private NotFoundObjectResult AccountNotFound(int id)
        {
            return NotFound(new { message = $"El cargo con ID = {id} no existe." });
        }
    }
}
