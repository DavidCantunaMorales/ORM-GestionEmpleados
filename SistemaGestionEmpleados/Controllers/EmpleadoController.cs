using BDOO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEmpleados.Servicios;

namespace SistemaGestionEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;
        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // OBTENER TODOS LOS EMPLEADOS
        [HttpGet]
        public async Task<IEnumerable<Empleado>> GetAll()
        {
            return await _empleadoService.GetEmpleados();
        }

        // OBTENER UN EMPLEADO
        [HttpGet("getEmpleado/{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id)
        {
            var empleado = await _empleadoService.GetEmpleado(id);
            if (empleado is null)
            {
                return AccountNotFound(id);
            }
            return empleado;
        }

        // CREAR UN NUEVO EMPLEADO
        [HttpPost("addCargo")]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            var newEmpleado = await _empleadoService.CreateEmpleado(empleado);
            return CreatedAtAction(nameof(GetById), new { id = empleado.IdEmp }, empleado);
        }

        // ACTUALIZAR UN EMPLEADO
        [HttpPut("updateEmpleado/{id}")]
        public async Task<IActionResult> Update(int id, Empleado empleado)
        {
            // VERIFICAR EL ID DE LA URL CON EL ID DEL JSON
            if (id != empleado.IdEmp)
            {
                return BadRequest(new { message = $"El ID({id}) de la URL no coincide con el ID({empleado.IdEmp}) del cuerpo de la solicitud" });
            }

            // ENCONTRANDO EL CARGO A ACTUALIZAR
            var empleadoUpdate = await _empleadoService.GetEmpleado(id);

            // VERIFICAR SI SE ENCUENTRA EL CARGO
            if (empleadoUpdate is not null)
            {
                await _empleadoService.UpdateEmpleado(id, empleado);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        // ELIMINAR UN CARGO
        [HttpDelete("deleteEmpleado/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleadoDelete = await _empleadoService.GetEmpleado(id);

            if (empleadoDelete is not null)
            {
                await _empleadoService.DeleteEmpleado(id);
                return Ok();
            }
            else
            {
                return AccountNotFound(id);
            }
        }

        private NotFoundObjectResult AccountNotFound(int id)
        {
            return NotFound(new { message = $"El empleado con ID = {id} no existe." });
        }
    }
}
