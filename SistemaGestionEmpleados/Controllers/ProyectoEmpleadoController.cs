using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoEmpleadoController : ControllerBase
    {
        private readonly ProyectoEmpleadoService _proyectoEmpleadoService;

        public ProyectoEmpleadoController(ProyectoEmpleadoService proyectoEmpleadoService)
        {
            _proyectoEmpleadoService = proyectoEmpleadoService;
        }

        // OBTENER TODOS LOS PROYECTOS EMPLEADO
        [HttpGet]
        public async Task<IEnumerable<ProyectoEmpleado>> GetAll()
        {
            return await _proyectoEmpleadoService.GetProyectoEmpleados();
        }

        // OBTENER UN PROYECTO EMPLEADO
        [HttpGet("getProyectoEmpleado/{idProyectoEmp}")]
        public async Task<ActionResult<ProyectoEmpleado>> GetById(int idProyectoEmp)
        {
            var proyectoEmpleado = await _proyectoEmpleadoService.GetProyectoEmpleado(idProyectoEmp);
            if (proyectoEmpleado is null)
            {
                return AccountNotFound(idProyectoEmp);
            }
            return proyectoEmpleado;
        }


        // CREAR UN NUEVO PROYECTO EMPLEADO
        [HttpPost("addProyecto")]
        public async Task<IActionResult> Create(ProyectoEmpleado proyectoEmpleado)
        {
            var newProyectoEmpleado = await _proyectoEmpleadoService.CreateProyecto(proyectoEmpleado);
            return CreatedAtAction(nameof(GetById), new { idProyectoEmp = newProyectoEmpleado.IdProyectoEmp }, newProyectoEmpleado);
        }

        // ACTUALIZAR UN PROYECTO EMPLEADO
        [HttpPut("updateProyecto/{id}")]
        public async Task<IActionResult> Update(int id, ProyectoEmpleado proyectoEmpleado)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != proyectoEmpleado.IdProyectoEmp)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({proyectoEmpleado.IdProyectoEmp}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL PROYECTO EMPLEADO A ACTUALIZAR
            var proyectoEmpleadoUpdate = await _proyectoEmpleadoService.GetProyectoEmpleado(id);

            // VERIFICAR SI SE ENCUENTRA EL PROYECTO EMPLEADO
            if (proyectoEmpleadoUpdate is not null)
            {
                await _proyectoEmpleadoService.UpdateProyectoEmpleado(id, proyectoEmpleado);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN PROYECTO EMPLEADO
        [HttpDelete("deleteProyectoEmpleado/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proyectoEmpleadoDelete = await _proyectoEmpleadoService.GetProyectoEmpleado(id);

            if (proyectoEmpleadoDelete is not null)
            {
                await _proyectoEmpleadoService.DeleteProyectoEmpleado(id);
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
