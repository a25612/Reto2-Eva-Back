using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(9)]
        public string DNI { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        public bool Activo { get; set; } = true;

        public string Rol { get; } = "TUTOR";

        public ICollection<UsuarioTutor> UsuariosTutores { get; set; }

        public Tutor() {}

        public Tutor(int id, string nombre, string dni, string email, string username, string password, bool activo)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            Email = email;
            Username = username;
            Password = password;
            Activo = activo;
            UsuariosTutores = new List<UsuarioTutor>();
        }
    }
}
