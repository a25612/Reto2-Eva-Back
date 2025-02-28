using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Piscina_Back.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITutorService _serviceTutor;
        private readonly IEmpleadoService _serviceEmpleado;
        private readonly IConfiguration _configuration;

        public AuthController(ITutorService serviceTutor, IEmpleadoService serviceEmpleado, IConfiguration configuration)
        {
            _serviceTutor = serviceTutor;
            _serviceEmpleado = serviceEmpleado;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PeticionLogin request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new { message = "El usuario y la contraseña son obligatorios" });
                }

                // Verificar si es un Tutor
                var tutor = await _serviceTutor.LoginAsync(request.Username, request.Password);
                if (tutor != null)
                {
                    var token = GenerateJwtToken(tutor.Id.ToString(), "Tutor");
                    return Ok(new
                    {
                        iduser = tutor.Id,
                        Rol = "Tutor",
                        Token = token
                    });
                }

                // Verificar si es un Empleado
                var empleado = await _serviceEmpleado.LoginAsync(request.Username, request.Password);
                if (empleado != null)
                {
                    var token = GenerateJwtToken(empleado.Id.ToString(), "Empleado");
                    return Ok(new
                    {
                        iduser = empleado.Id,
                        Rol = "Empleado",
                        Token = token
                    });
                }

                return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        private string GenerateJwtToken(string userId, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class PeticionLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
