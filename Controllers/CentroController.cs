using Microsoft.AspNetCore.Mvc;
using Service;
using Models;

namespace Pisicna_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroController : ControllerBase
    {
        private readonly ICentroService _serviceCentro;

        public CentroController(ICentroService service)
        {
            _serviceCentro = service;
        }

        // Obtener todos los centros
        [HttpGet]
        public async Task<ActionResult<List<Centro>>> GetCentros()
        {
            var centros = await _serviceCentro.GetAllAsync();
            return Ok(centros);
        }

        // Obtener un centro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Centro>> GetCentro(int id)
        {
            var centro = await _serviceCentro.GetByIdAsync(id);

            if (centro == null)
            {
                return NotFound();
            }

            return Ok(centro);
        }

        // Crear un nuevo centro
        [HttpPost]
        public async Task<ActionResult<Centro>> CreateCentro(Centro centro)
        {
            await _serviceCentro.AddAsync(centro);
            return CreatedAtAction(nameof(GetCentro), new { id = centro.Id }, centro);
        }

        // Actualizar un centro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCentro(int id, Centro centro)
        {
            if (id != centro.Id)
            {
                return BadRequest();
            }

            var existingCentro = await _serviceCentro.GetByIdAsync(id);
            if (existingCentro == null)
            {
                return NotFound();
            }

            await _serviceCentro.UpdateAsync(centro);
            return NoContent();
        }

        // Eliminar un centro por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentro(int id)
        {
            var centro = await _serviceCentro.GetByIdAsync(id);
            if (centro == null)
            {
                return NotFound();
            }

            await _serviceCentro.DeleteAsync(id);
            return NoContent();
        }
    }
}
