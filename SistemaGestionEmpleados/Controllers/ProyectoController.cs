using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectoService _proyectoService;

        public ProyectoController(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;
        }

        // OBTENER TODOS LOS PROYECTOS
        [HttpGet]
        public async Task<IEnumerable<Proyecto>> GetAll()
        {
            return await _proyectoService.GetProyectos();
        }

        // OBTENER UN PROYECTO
        [HttpGet("getProyecto/{id}")]
        public async Task<ActionResult<Proyecto>> GetById(int id)
        {
            var proyecto = await _proyectoService.GetProyecto(id);
            if (proyecto is null)
            {
                return AccountNotFound(id);
            }
            return proyecto;
        }

        // CREAR UN NUEVO PROYECTO
        [HttpPost("addProyecto")]
        public async Task<IActionResult> Create(Proyecto proyecto)
        {
            var newProyecto = await _proyectoService.CreateProyecto(proyecto);
            return CreatedAtAction(nameof(GetById), new { id = proyecto.IdProyecto }, proyecto);
        }

        // ACTUALIZAR UN PROYECTO
        [HttpPut("updateProyecto/{id}")]
        public async Task<IActionResult> Update(int id, Proyecto proyecto)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != proyecto.IdProyecto) {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({proyecto.IdProyecto}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL PROYECTO A ACTUALIZAR
            var proyectoUpdate = await _proyectoService.GetProyecto(id);

            // VERIFICAR SI SE ENCUENTRA EL PROYECTO
            if (proyectoUpdate is not null) {
                await _proyectoService.UpdateProyecto(id, proyecto);
                return Ok();
            }
            else {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN PROYECTO
        [HttpDelete("deleteDepartamento/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proyectoDelete = await _proyectoService.GetProyecto(id);

            if (proyectoDelete is not null) {
                await _proyectoService.DeleteProyecto(id);
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
