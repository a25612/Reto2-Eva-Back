using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(9)]
        public string DNI { get; set; }

        public int JornadaTotalHoras { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public string Rol { get; set; } = "EMPLEADO";

        public ICollection<EmpleadosCentros> EmpleadosCentros { get; set; }

        public Empleado()
        {
            EmpleadosCentros = new List<EmpleadosCentros>();
        }
    }
}
