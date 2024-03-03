using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly SupervisorService _supervisorService;
        public SupervisorController(SupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }

        // OBTENER TODOS LOS SUPERVISORES
        [HttpGet]
        public async Task<IEnumerable<Supervisor>> GetAll()
        {
            return await _supervisorService.GetSupervisores();
        }

        // OBTENER UN SUPERVISOR
        [HttpGet("getSupervisor/{id}")]
        public async Task<ActionResult<Supervisor>> GetById(int id)
        {
            var supervisor = await _supervisorService.GetSupervisor(id);
            if (supervisor is null)
            {
                return AccountNotFound(id);
            }
            return supervisor;
        }

        // CREAR UN NUEVO SUPERVISOR
        [HttpPost("addSupervisor")]
        public async Task<IActionResult> Create(Supervisor supervisor)
        {
            var newSupervisor = await _supervisorService.CreateSupervisor(supervisor);
            return CreatedAtAction(nameof(GetById), new { id = supervisor.IdSup }, supervisor);
        }

        // ACTUALIZAR UN SUPERVISOR
        [HttpPut("updateSupervisor/{id}")]
        public async Task<IActionResult> Update(int id, Supervisor supervisor)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != supervisor.IdSup)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({supervisor.IdSup}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL SUPERVISOR A ACTUALIZAR
            var supervisorUpdate = await _supervisorService.GetSupervisor(id);

            // VERIFICAR SI SE ENCUENTRA EL CARGO
            if (supervisorUpdate is not null)
            {
                await _supervisorService.UpdateSupervisor(id, supervisor);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN SUPERVISOR
        [HttpDelete("deleteSupervisor/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supervisorDelete = await _supervisorService.GetSupervisor(id);

            if (supervisorDelete is not null)
            {
                await _supervisorService.DeleteSupervisor(id);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        private NotFoundObjectResult AccountNotFound(int id)
        {
            return NotFound(new { message = $"El supervisor con ID = {id} no existe." });
        }

    }
}
