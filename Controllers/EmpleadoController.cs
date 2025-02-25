using Microsoft.AspNetCore.Mvc;
using Service;
using Models;

namespace Pisicna_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _serviceEmpleado;

        public EmpleadoController(IEmpleadoService service)
        {
            _serviceEmpleado = service;
        }

        // Obtener todos los empleados
        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            var empleados = await _serviceEmpleado.GetAllAsync();
            return Ok(empleados);
        }

        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _serviceEmpleado.GetByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        // Crear un nuevo empleado
        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateEmpleado(Empleado empleado)
        {
            await _serviceEmpleado.AddAsync(empleado);
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        // Actualizar un empleado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, Empleado updatedEmpleado)
        {
            var existingEmpleado = await _serviceEmpleado.GetByIdAsync(id);
            if (existingEmpleado == null)
            {
                return NotFound();
            }

            // Actualizar los campos del empleado existente
            existingEmpleado.Nombre = updatedEmpleado.Nombre;
            existingEmpleado.DNI = updatedEmpleado.DNI;
            existingEmpleado.JornadaTotalHoras = updatedEmpleado.JornadaTotalHoras;
            existingEmpleado.Centro = updatedEmpleado.Centro;

            await _serviceEmpleado.UpdateAsync(existingEmpleado);
            return NoContent();
        }

        // Eliminar un empleado por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _serviceEmpleado.GetByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            await _serviceEmpleado.DeleteAsync(id);
            return NoContent();
        }
    }
}
