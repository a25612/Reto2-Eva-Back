using Microsoft.AspNetCore.Mvc;
using Service;
using Models;
using DTOs;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionService _sesionService;

        public SesionController(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        // Obtener todas las sesiones
        [HttpGet]
        public async Task<ActionResult<List<Sesion>>> GetSesiones()
        {
            var sesiones = await _sesionService.GetAllAsync();
            return Ok(sesiones);
        }

        // Obtener sesiones por ID de usuario
        [HttpGet("Usuario/{idUsuario}")]
        public async Task<ActionResult<List<Sesion>>> GetSesionesByUsuario(int idUsuario)
        {
            var sesiones = await _sesionService.GetByUsuarioIdAsync(idUsuario);
            if (sesiones == null || !sesiones.Any())
            {
                return NotFound(new { Message = $"No se encontraron sesiones para el usuario con ID {idUsuario}." });
            }
            return Ok(sesiones);
        }

        // Obtener sesiones por ID de empleado
        [HttpGet("Empleado/{idEmpleado}")]
        public async Task<ActionResult<List<Sesion>>> GetSesionesByEmpleado(int idEmpleado)
        {
            var sesiones = await _sesionService.GetByEmpleadoIdAsync(idEmpleado);
            if (sesiones == null || !sesiones.Any())
            {
                return NotFound(new { Message = $"No se encontraron sesiones para el empleado con ID {idEmpleado}." });
            }
            return Ok(sesiones);
        }

        // Crear una nueva sesión usando DTO
        [HttpPost]
        public async Task<ActionResult<Sesion>> CreateSesion([FromBody] CrearSesionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevaSesion = new Sesion
            {
                ID_CENTRO = dto.IdCentro,
                ID_SERVICIO = dto.IdServicio,
                ID_OPCION_SERVICIO = dto.IdOpcionServicio,
                ID_USUARIO = dto.IdUsuario,
                ID_TUTOR = dto.IdTutor,
                FECHA = DateTime.UtcNow, 
                FACTURAR = false 
            };

            await _sesionService.AddAsync(nuevaSesion);

            return CreatedAtAction(nameof(GetSesiones), new { id = nuevaSesion.ID }, nuevaSesion);
        }

        // Actualizar una sesión existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSesion(int id, Sesion updatedSesion)
        {
            if (id != updatedSesion.ID)
            {
                return BadRequest();
            }

            var existingSesion = await _sesionService.GetByIdAsync(id);
            if (existingSesion == null)
            {
                return NotFound();
            }

            await _sesionService.UpdateAsync(updatedSesion);
            return NoContent();
        }

        // Eliminar una sesión por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var sesion = await _sesionService.GetByIdAsync(id);
            if (sesion == null)
            {
                return NotFound();
            }

            await _sesionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
