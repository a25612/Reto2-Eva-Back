using Microsoft.AspNetCore.Mvc;
using Service;
using Models;

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

        // Crear un nuevo tutor
        [HttpPost]
        public async Task<IActionResult> Create(Tutor tutor)
        {
            await _serviceTutor.AddAsync(tutor);
            return CreatedAtAction(nameof(GetById), new { id = tutor.Id }, tutor);
        }

        // Actualizar un tutor existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tutor updatedTutor)
        {
            var existingTutor = await _serviceTutor.GetByIdAsync(id);

            if (existingTutor == null)
                return NotFound();

            existingTutor.Nombre = updatedTutor.Nombre;
            existingTutor.DNI = updatedTutor.DNI;
            existingTutor.Email = updatedTutor.Email;
            existingTutor.Username = updatedTutor.Username;
            existingTutor.Password = updatedTutor.Password;
            existingTutor.Activo = updatedTutor.Activo;

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
