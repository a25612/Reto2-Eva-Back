using Microsoft.AspNetCore.Mvc;
using Service;
using Models;
using DTOs;
using AutoMapper;

namespace Pisicna_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _serviceUsuario;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuariosService service, IMapper mapper)
        {
            _serviceUsuario = service;
            _mapper = mapper;
        }

        // Obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuario()
        {
            var usuarios = await _serviceUsuario.GetAllAsync();
            return Ok(usuarios);
        }

        // Obtener un usuario por ID
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

        // Crear un nuevo usuario
        // Crear un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(CreateUsuario createUsuario)
        {
            // Mapear CreateUsuario a Usuario
            var usuario = _mapper.Map<Usuario>(createUsuario);

            // Agregar el usuario mediante el servicio
            await _serviceUsuario.AddAsync(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }


        // Actualizar un usuario existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            var existingUsuario = await _serviceUsuario.GetByIdAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            // Mapear los datos del DTO al modelo existente
            _mapper.Map(updatedUsuario, existingUsuario);

            await _serviceUsuario.UpdateAsync(existingUsuario);
            return NoContent();
        }

        // Eliminar un usuario por ID
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