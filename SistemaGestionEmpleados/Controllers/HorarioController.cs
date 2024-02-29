using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private BDContext _context;

        public HorarioController(BDContext context)
        {
            _context = context;
        }

        // OBTENER TODOS LOS  HORARIOS
        [HttpGet]
        public async Task<IEnumerable<Horario>> GetAll()
        {
            return await _context.Horarios.ToListAsync();
        }

        // OBTENER UN HORARIO
        [HttpGet("getHorario/{id}")]
        public async Task<ActionResult<Horario>> GetById(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario is null)
            {
                return AccountNotFound(id);
            }
            return horario;
        }

        // CREAR UN NUEVO HORARIO
        [HttpPost("addHorario")]
        public async Task<ActionResult<Horario>> Create(Horario horario)
        {
            _context.Horarios.Add(horario);
            var newHorario = await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = horario.IdHorario }, horario);
        }

        // ACTUALIZAR UN HORARIO
        [HttpPut("updateHorario/{id}")]
        public async Task<ActionResult> Update(int id, Horario horario)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != horario.IdHorario)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({horario.IdHorario}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL CARGO A ACTUALIZAR
            var horarioUpdate = await _context.Horarios.FindAsync(id);

            // VERIFICAR SI SE ENCUENTRA EL CARGO
            if (horarioUpdate is not null)
            {
                horarioUpdate.HoraEntrada = horario.HoraEntrada;
                horarioUpdate.HoraSalida = horario.HoraSalida;
                await _context.SaveChangesAsync();
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
            var horarioDelete = await _context.Horarios.FindAsync(id);

            if (horarioDelete is not null)
            {
                _context.Horarios.Remove(horarioDelete);
                await _context.SaveChangesAsync();
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
