using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class ActualizarTutorDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string Email { get; set; }   
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Activo { get; set; }
    }

}