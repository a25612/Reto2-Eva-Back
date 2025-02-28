using Microsoft.AspNetCore.Mvc;
using Service;
using Models;

namespace Pisicna_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosService _serviceServicios;

        public ServiciosController(IServiciosService service)
        {
            _serviceServicios = service;
        }

        // Obtener todos los empleados
        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> GetServicio()
        {
            var empleados = await _serviceServicios.GetAllAsync();
            return Ok(empleados);
        }

        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetServicio(int id)
        {
            var servicio = await _serviceServicios.GetByIdAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        // Obtener servicios por id centro
        [HttpGet("porCentro/{centroId}")]
        public async Task<ActionResult<List<Servicio>>> GetServiciosPorCentro(int centroId)
        {
            var servicios = await _serviceServicios.GetServiciosByCentroIdAsync(centroId);
            return Ok(servicios);
        }


        // Crear un nuevo empleado
        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateServicio(Servicio servicio)
        {
            await _serviceServicios.AddAsync(servicio);
            return CreatedAtAction(nameof(GetServicio), new { id = servicio.Id }, servicio);
        }

        // Actualizar un empleado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicio(int id, Servicio updatedServicio)
        {
            var existingServicio = await _serviceServicios.GetByIdAsync(id);
            if (existingServicio == null)
            {
                return NotFound();
            }

            // Actualizar los campos del empleado existente
            existingServicio.Nombre = updatedServicio.Nombre;
            existingServicio.Precio = updatedServicio.Precio;
            existingServicio.Descripcion = updatedServicio.Descripcion;

            await _serviceServicios.UpdateAsync(existingServicio);
            return NoContent();
        }

        // Eliminar un empleado por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            var servicio = await _serviceServicios.GetByIdAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            await _serviceServicios.DeleteAsync(id);
            return NoContent();
        }
    }
}
