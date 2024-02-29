using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoService _cargoService;

        public CargoController(CargoService cargoService)
        {
            _cargoService = cargoService;
        }

        // OBTENER TODOS LOS CARGOS
        [HttpGet]
        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _cargoService.GetCargos();
        }

        // OBTENER UN CARGO
        [HttpGet("getCargo/{id}")]
        public async Task<ActionResult<Cargo>> GetById(int id)
        {
            var cargo = await _cargoService.GetCargo(id);
            if (cargo is null) {
                return AccountNotFound(id);
            }
            return cargo;
        }

        // CREAR UN NUEVO CARGO
        [HttpPost("addCargo")]
        public async Task<IActionResult> Create(Cargo cargo)
        {
            var newCargo = await _cargoService.CreateCargo(cargo);
            return CreatedAtAction(nameof(GetById), new { id = cargo.IdCargo }, cargo);
        }

        // ACTUALIZAR UN CARGO
        [HttpPut("updateCargo/{id}")]
        public async Task<IActionResult> Update(int id, Cargo cargo)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != cargo.IdCargo) {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({cargo.IdCargo}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL CARGO A ACTUALIZAR
            var cargoUpdate = await _cargoService.GetCargo(id);

            // VERIFICAR SI SE ENCUENTRA EL CARGO
            if (cargoUpdate is not null) {
                await _cargoService.UpdateCargo(id, cargo);
                return Ok();
            }
            else{
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN CARGO
        [HttpDelete("deleteCargo/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cargoDelete = await _cargoService.GetCargo(id);

            if (cargoDelete is not null) {
                await _cargoService.DeleteCargo(id);
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
