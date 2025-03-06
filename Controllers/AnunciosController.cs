using Microsoft.AspNetCore.Mvc;
using Service;
using Models;
using DTOs;

namespace Piscina_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _serviceAnuncio;

        public AnuncioController(IAnuncioService service)
        {
            _serviceAnuncio = service;
        }

        // Obtener todos los anuncios
        [HttpGet]
        public async Task<ActionResult<List<Anuncio>>> GetAnuncios()
        {
            var anuncios = await _serviceAnuncio.GetAllAsync();
            return Ok(anuncios);
        }

        // Obtener un anuncio por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> GetAnuncio(int id)
        {
            var anuncio = await _serviceAnuncio.GetByIdAsync(id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return Ok(anuncio);
        }

        // Crear un nuevo anuncio
        [HttpPost]
        public async Task<ActionResult<Anuncio>> CreateAnuncio(CrearAnuncioDTO anuncioDto)
        {
            var anuncio = new Anuncio
            {
                Titulo = anuncioDto.Titulo,
                Descripcion = anuncioDto.Descripcion,
            };

            await _serviceAnuncio.AddAsync(anuncio);
            return CreatedAtAction(nameof(GetAnuncio), new { id = anuncio.Id }, anuncio);
        }


        // Actualizar un anuncio existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnuncio(int id, Anuncio anuncio)
        {   
            if (id != anuncio.Id)
            {
                return BadRequest();
            }

            var existingAnuncio = await _serviceAnuncio.GetByIdAsync(id);
            if (existingAnuncio == null)
            {
                return NotFound();
            }

            await _serviceAnuncio.UpdateAsync(anuncio);
            return NoContent();
        }

        // Eliminar un anuncio por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnuncio(int id)
        {
            var anuncio = await _serviceAnuncio.GetByIdAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }

            await _serviceAnuncio.DeleteAsync(id);
            return NoContent();
        }
    }
}
