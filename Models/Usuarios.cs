using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(9)]
        public string DNI { get; set; }

        [Required]
        [MaxLength(10)]
        public string CodigoFacturacion { get; set; }

        [ForeignKey("Centro")]
        public int IdCentro { get; set; }
        public Centro Centro { get; set; }

        // Relación con Usuarios_Tutores (N:N)
        public ICollection<UsuarioTutor> UsuariosTutores { get; set; }

        // Relación con Sesiones
        public ICollection<Sesion> Sesiones { get; set; }

        // Constructor vacío (necesario para EF Core)
        public Usuario()
        {
            UsuariosTutores = new List<UsuarioTutor>();
            Sesiones = new List<Sesion>();
        }

        // Constructor completo
        public Usuario(int id, string nombre, string dni, string codigoFacturacion, int idCentro)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            CodigoFacturacion = codigoFacturacion;
            IdCentro = idCentro;

            UsuariosTutores = new List<UsuarioTutor>();
            Sesiones = new List<Sesion>();
        }
    }
}