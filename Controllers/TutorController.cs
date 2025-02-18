using Microsoft.AspNetCore.Mvc;
using Pisicna_Back.Repositories;
using Pisicna_Back.Service;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        // Obtener todos los empleados
        [HttpGet]
        public async Task<ActionResult<List<Tutor>>> GetTutor()
        {
            var tutor = await _serviceTutor.GetAllAsync();
            return Ok(tutor);
        }

        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
            var tutor = await _serviceTutor.GetByIdAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            return Ok(tutor);
        }

        // Crear un nuevo empleado
        [HttpPost]
        public async Task<ActionResult<Tutor>> CreateTutor(Tutor tutor)
        {
            await _serviceTutor.AddAsync(tutor);
            return CreatedAtAction(nameof(GetTutor), new { id = tutor.Id }, tutor);
        }

        // Actualizar un empleado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSesion(int id, Tutor updatedTutor)
        {
            var existingTutor = await _serviceTutor.GetByIdAsync(id);
            if (existingTutor == null)
            {
                return NotFound();
            }

            // Actualizar los campos del tutor existente
            existingTutor.Nombre = updatedTutor.Nombre;
            existingTutor.DNI = updatedTutor.DNI;
            existingTutor.Email = updatedTutor.Email;
            existingTutor.Username = updatedTutor.Username;
            existingTutor.Password = updatedTutor.Password;
            existingTutor.Activo = updatedTutor.Activo;

            await _serviceTutor.UpdateAsync(existingTutor);
            return NoContent();
        }

        // Eliminar un empleado por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            var tutor = await _serviceTutor.GetByIdAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            await _serviceTutor.DeleteAsync(id);
            return NoContent();
        }

    }
}
