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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _serviceUsuario;

        public UsuariosController(IUsuariosService service)
        {
            _serviceUsuario = service;
        }

        // Obtener todos los empleados
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuario()
        {
            var usuario = await _serviceUsuario.GetAllAsync();
            return Ok(usuario);
        }

        // Obtener un empleado por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _serviceUsuario.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // Crear un nuevo empleado
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            await _serviceUsuario.AddAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // Actualizar un empleado existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            var existingUsuario = await _serviceUsuario.GetByIdAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            // Actualizar los campos del empleado existente
            existingUsuario.Nombre = updatedUsuario.Nombre;
            existingUsuario.DNI = updatedUsuario.DNI;
            existingUsuario.CodigoFacturacion = updatedUsuario.CodigoFacturacion;

            await _serviceUsuario.UpdateAsync(existingUsuario);
            return NoContent();
        }

        // Eliminar un empleado por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _serviceUsuario.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _serviceUsuario.DeleteAsync(id);
            return NoContent();
        }
    }
}
