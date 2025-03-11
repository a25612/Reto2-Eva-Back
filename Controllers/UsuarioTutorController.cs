using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioTutoresController : ControllerBase
    {
        private readonly IUsuarioTutorService _service;

        public UsuarioTutoresController(IUsuarioTutorService service)
        {
            _service = service;
        }

        // Obtener todos los UsuarioTutores
        [HttpGet]
        public async Task<ActionResult<List<UsuarioTutor>>> GetAll()
        {
            var usuarioTutores = await _service.GetAllAsync();
            return Ok(usuarioTutores);
        }

        // Obtener un UsuarioTutor por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioTutor>> GetById(int id)
        {
            var usuarioTutor = await _service.GetByIdAsync(id);

            if (usuarioTutor == null)
                return NotFound();

            return Ok(usuarioTutor);
        }

        // Obtener UsuarioTutores por ID de Usuario
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<IEnumerable<UsuarioTutor>>> GetByUsuarioId(int idUsuario)
        {
            var usuarioTutores = await _service.GetByUsuarioIdAsync(idUsuario);
            return Ok(usuarioTutores);
        }

        // Obtener UsuarioTutores por ID de Tutor
        [HttpGet("tutor/{idTutor}")]
        public async Task<ActionResult<IEnumerable<UsuarioTutor>>> GetByTutorId(int idTutor)
        {
            var usuarioTutores = await _service.GetByTutorIdAsync(idTutor);
            return Ok(usuarioTutores);
        }

        // Crear un nuevo UsuarioTutor
        [HttpPost]
        public async Task<ActionResult<UsuarioTutor>> Create([FromBody] UsuarioTutor usuarioTutor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(usuarioTutor);
            return CreatedAtAction(nameof(GetById), new { id = usuarioTutor.Id }, usuarioTutor);
        }

        // Actualizar un UsuarioTutor existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioTutor usuarioTutor)
        {
            if (id != usuarioTutor.Id)
                return BadRequest("El ID no coincide.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUsuarioTutor = await _service.GetByIdAsync(id);
            if (existingUsuarioTutor == null)
                return NotFound();

            await _service.UpdateAsync(usuarioTutor);
            return NoContent();
        }

        // Eliminar un UsuarioTutor por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUsuarioTutor = await _service.GetByIdAsync(id);
            if (existingUsuarioTutor == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
