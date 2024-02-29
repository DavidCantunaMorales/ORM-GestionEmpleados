using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private BDContext _context;

        public DepartamentoController(BDContext context)
        {
            _context = context;
        }

        // OBTENER TODOS LOS DEPARTAMENTOS
        [HttpGet]
        public async Task<IEnumerable<Departamento>> GetAll()
        {
            return await _context.Departamentos.ToListAsync();
        }

        // OBTENER UN DEPARTAMENTO
        [HttpGet("getDepartamento/{id}")]
        public async Task<ActionResult<Departamento>> GetById(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento is null)
            {
                return AccountNotFound(id);
            }
            return departamento;
        }

        // CREAR UN NUEVO DEPARTAMENTO
        [HttpPost("addDepartamento")]
        public async Task<ActionResult<Departamento>> Create(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            var newDepartamento = await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = departamento.IdDep }, departamento);
        }

        // ACTUALIZAR UN DEPARTAMENTO
        [HttpPut("updateDepartamento/{id}")]
        public async Task<ActionResult> Update(int id, Departamento departamento)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != departamento.IdDep)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({departamento.IdDep}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL DEPARTAMENTO A ACTUALIZAR
            var departamentoUpdate = await _context.Departamentos.FindAsync(id);

            // VERIFICAR SI SE ENCUENTRA EL DEPARTAMENTO
            if (departamentoUpdate is not null)
            {
                departamentoUpdate.NombreDep = departamento.NombreDep;
                departamentoUpdate.DescripcionDep = departamento.DescripcionDep;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN DEPARTAMENTO
        [HttpDelete("deleteDepartamento/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var departamentoDelete = await _context.Departamentos.FindAsync(id);

            if (departamentoDelete is not null)
            {
                _context.Departamentos.Remove(departamentoDelete);
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
            return NotFound(new { message = $"El departamento con ID = {id} no existe." });
        }

    }
}
