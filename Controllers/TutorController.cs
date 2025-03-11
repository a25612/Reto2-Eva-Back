using Microsoft.AspNetCore.Mvc;
using Service;
using Models;
using DTOs;

namespace Pisicna_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _serviceTutor;

        public TutorController(ITutorService service)
        {
            _serviceTutor = service;
        }

        // Obtener todos los tutores
        [HttpGet]
        public async Task<ActionResult<List<Tutor>>> GetAll()
        {
            var tutores = await _serviceTutor.GetAllAsync();
            return Ok(tutores);
        }

        // Obtener un tutor por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetById(int id)
        {
            var tutor = await _serviceTutor.GetByIdAsync(id);

            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        // Obtener usuarios asignados a un tutor
        [HttpGet("{id}/usuarios")]
        public async Task<ActionResult<List<Usuario>>> GetUsuariosByTutorId(int id)
        {
            var tutor = await _serviceTutor.GetByIdAsync(id);

            if (tutor == null)
                return NotFound($"No se encontró el tutor con ID {id}");

            var usuarios = await _serviceTutor.GetUsuariosByTutorIdAsync(id);

            return Ok(usuarios);
        }


        // Crear un nuevo tutor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearTutorDTO crearTutorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var tutor = new Tutor
            {
                Nombre = crearTutorDTO.Nombre,
                DNI = crearTutorDTO.DNI,
                Email = crearTutorDTO.Email,
                Username = crearTutorDTO.Username,
                Password = crearTutorDTO.Password,
                Activo = crearTutorDTO.Activo
            };

            await _serviceTutor.AddAsync(tutor);

            return CreatedAtAction(nameof(GetById), new { id = tutor.Id }, tutor);
        }
        // Actualizar un tutor existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarTutorDTO actualizarTutorDTO)
        {
            var existingTutor = await _serviceTutor.GetByIdAsync(id);

            if (existingTutor == null)
                return NotFound();

            existingTutor.Nombre = actualizarTutorDTO.Nombre;
            existingTutor.DNI = actualizarTutorDTO.DNI;
            existingTutor.Email = actualizarTutorDTO.Email;
            existingTutor.Username = actualizarTutorDTO.Username;
            existingTutor.Password = actualizarTutorDTO.Password;
            existingTutor.Activo = actualizarTutorDTO.Activo;

            await _serviceTutor.UpdateAsync(existingTutor);

            return NoContent();
        }


        // Eliminar un tutor por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTutor = await _serviceTutor.GetByIdAsync(id);

            if (existingTutor == null)
                return NotFound();

            await _serviceTutor.DeleteAsync(id);

            return NoContent();
        }
    }
}
