using Microsoft.AspNetCore.Mvc;
using Service;
using Models;

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

        // Crear una nueva sesión
        [HttpPost]
        public async Task<ActionResult<Sesion>> CreateSesion(Sesion sesion)
        {
            await _sesionService.AddAsync(sesion);
            return CreatedAtAction(nameof(GetSesiones), new { id = sesion.Id }, sesion);
        }

        // Actualizar una sesión existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSesion(int id, Sesion updatedSesion)
        {
            var existingSesion = await _sesionService.GetByIdAsync(id);
            if (existingSesion == null)
            {
                return NotFound();
            }

            existingSesion.Fecha = updatedSesion.Fecha;
            existingSesion.ID_USUARIO = updatedSesion.ID_USUARIO;
            existingSesion.ID_EMPLEADO = updatedSesion.ID_EMPLEADO;
            existingSesion.ID_SERVICIO = updatedSesion.ID_SERVICIO;
            existingSesion.Facturar = updatedSesion.Facturar;

            await _sesionService.UpdateAsync(existingSesion);
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
