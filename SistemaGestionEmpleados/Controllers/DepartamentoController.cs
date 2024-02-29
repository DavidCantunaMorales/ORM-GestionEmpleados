using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentoController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // OBTENER TODOS LOS DEPARTAMENTOS
        [HttpGet]
        public async Task<IEnumerable<Departamento>> GetAll()
        {
            return await _departamentoService.GetDepartamentos();
        }

        // OBTENER UN DEPARTAMENTO
        [HttpGet("getDepartamento/{id}")]
        public async Task<ActionResult<Departamento>> GetById(int id)
        {
            var departamento = await _departamentoService.GetDepartamento(id);
            if (departamento is null)
            {
                return AccountNotFound(id);
            }
            return departamento;
        }

        // CREAR UN NUEVO DEPARTAMENTO
        [HttpPost("addDepartamento")]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            var newDepartamento = await _departamentoService.CreateDepartamento(departamento);
            return CreatedAtAction(nameof(GetById), new { id = departamento.IdDep }, departamento);
        }

        // ACTUALIZAR UN DEPARTAMENTO
        [HttpPut("updateDepartamento/{id}")]
        public async Task<IActionResult> Update(int id, Departamento departamento)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != departamento.IdDep)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({departamento.IdDep}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL DEPARTAMENTO A ACTUALIZAR
            var departamentoUpdate = await _departamentoService.GetDepartamento(id);

            // VERIFICAR SI SE ENCUENTRA EL DEPARTAMENTO
            if (departamentoUpdate is not null) {
                await _departamentoService.UpdateDepartamento(id, departamento);
                return Ok();
            }
            else {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN DEPARTAMENTO
        [HttpDelete("deleteDepartamento/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var departamentoDelete = await _departamentoService.GetDepartamento(id);

            if (departamentoDelete is not null) {
                await _departamentoService.DeleteDepartamento(id);
                return Ok();
            }
            else {
                return AccountNotFound(id);
            }
        }

        private NotFoundObjectResult AccountNotFound(int id)
        {
            return NotFound(new { message = $"El departamento con ID = {id} no existe." });
        }

    }
}
