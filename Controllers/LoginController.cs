using Microsoft.AspNetCore.Mvc;
using Pisicna_Back.Service;

namespace Pisicna_Back.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITutorService _serviceTutor;
        private readonly IEmpleadoService _serviceEmpleado;

        public AuthController(ITutorService serviceTutor, IEmpleadoService serviceEmpleado)
        {
            _serviceTutor = serviceTutor;
            _serviceEmpleado = serviceEmpleado;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PeticionLogin request)
        {
            try
            {
                // Verificar si se envió un usuario y contraseña válidos
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new { message = "El usuario y la contraseña son obligatorios" });
                }

                // Buscar en la tabla de Tutores
                var tutor = await _serviceTutor.LoginAsync(request.Username, request.Password);
                if (tutor != null)
                {
                    return Ok(new
                    {
                        Id = tutor.Id,
                        Nombre = tutor.Nombre,
                        Email = tutor.Email,
                        Username = tutor.Username,
                        Rol = "Tutor"
                    });
                }

                // Buscar en la tabla de Empleados
                var empleado = await _serviceEmpleado.LoginAsync(request.Username, request.Password);
                if (empleado != null)
                {
                    return Ok(new
                    {
                        Id = empleado.Id,
                        Nombre = empleado.Nombre,
                        JornadaTotalHoras = empleado.JornadaTotalHoras,
                        Username = empleado.Username,
                        Rol = "Empleado"
                    });
                }

                return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        public class PeticionLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
