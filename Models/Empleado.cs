using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string Rol { get; } = "EMPLEADO";
        public int IdCentro { get; set; } 

        [ForeignKey("Centro")]
        public int IdCentro { get; set; }
        public Centros Centro { get; set; }

        // Relación con Sesiones
        public ICollection<Sesiones> Sesiones { get; set; }

        // Constructor vacío (necesario para EF Core)
        public Empleado() {}

        // Constructor completo
        public Empleado(int id, string nombre, string dni, int jornadaTotalHoras, string username, string password, int idCentro)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            JornadaTotalHoras = jornadaTotalHoras;
            Username = username;
            Password = password;
            IdCentro = idCentro;
        }
    }
}
