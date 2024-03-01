using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly HorarioService _horarioService;
        public HorarioController(HorarioService horarioService)
        {
            _horarioService = horarioService;
        }

        // OBTENER TODOS LOS  HORARIOS
        [HttpGet]
        public async Task<IEnumerable<Horario>> GetAll()
        {
            return await _horarioService.GetHorarios();
        }

        // OBTENER UN HORARIO
        [HttpGet("getHorario/{id}")]
        public async Task<ActionResult<Horario>> GetById(int id)
        {
            var horario = await _horarioService.GetHorario(id);
            if (horario is null)
            {
                return AccountNotFound(id);
            }
            return horario;
        }

        // CREAR UN NUEVO HORARIO
        [HttpPost("addHorario")]
        public async Task<IActionResult> Create(Horario horario)
        {
            var newHorario = await _horarioService.CreateHorario(horario);
            return CreatedAtAction(nameof(GetById), new { id = horario.IdHorario }, horario);
        }

        // ACTUALIZAR UN HORARIO
        [HttpPut("updateHorario/{id}")]
        public async Task<IActionResult> Update(int id, Horario horario)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != horario.IdHorario)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({horario.IdHorario}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL CARGO A ACTUALIZAR
            var horarioUpdate = await _horarioService.GetHorario(id);

            // VERIFICAR SI SE ENCUENTRA EL CARGO
            if (horarioUpdate is not null)
            {
                await _horarioService.UpdateHorario(id, horario);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN HORARIO
        [HttpDelete("deleteHorario/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var horarioDelete = await _horarioService.GetHorario(id);

            if (horarioDelete is not null)
            {
                await _horarioService.DeleteEmpleado(id);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        private NotFoundObjectResult AccountNotFound(int id)
        {
            return NotFound(new { message = $"El horario con ID = {id} no existe." });
        }

    }
}
