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

        // Obtener todos los servicios
        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> GetServicio()
        {
            var servicios = await _serviceServicios.GetAllAsync();
            return Ok(servicios);
        }

        // Obtener un servicio por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _serviceServicios.GetByIdAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        // Obtener servicios por id centro (incluyendo opciones)
        [HttpGet("centros/{centroId}")]
        public async Task<ActionResult<List<Servicio>>> GetServiciosPorCentro(int centroId)
        {
            var servicios = await _serviceServicios.GetServiciosByCentroIdAsync(centroId);
            return Ok(servicios);
        }

        // Obtener opciones de un servicio específico
        [HttpGet("{id}/opciones")]
        public async Task<ActionResult<List<OpcionServicio>>> GetOpcionesServicio(int id)
        {
            var opciones = await _serviceServicios.GetOpcionesServicioAsync(id);
            if (opciones == null || !opciones.Any())
            {
                return NotFound();
            }
            return Ok(opciones);
        }

        // Crear un nuevo servicio
        [HttpPost]
        public async Task<ActionResult<Servicio>> CreateServicio(Servicio servicio)
        {
            await _serviceServicios.AddAsync(servicio);
            return CreatedAtAction(nameof(GetServicio), new { id = servicio.Id }, servicio);
        }

        // Actualizar un servicio existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicio(int id, Servicio updatedServicio)
        {
            var existingServicio = await _serviceServicios.GetByIdAsync(id);
            if (existingServicio == null)
            {
                return NotFound();
            }

            // Actualizar los campos del servicio existente
            existingServicio.Nombre = updatedServicio.Nombre;
            existingServicio.Descripcion = updatedServicio.Descripcion;
            existingServicio.Activo = updatedServicio.Activo;
            existingServicio.Opciones = updatedServicio.Opciones;

            await _serviceServicios.UpdateAsync(existingServicio);
            return NoContent();
        }

        // Eliminar un servicio por ID
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