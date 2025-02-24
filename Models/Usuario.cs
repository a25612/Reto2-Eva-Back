using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonIgnore] 
        public ICollection<UsuarioCentro> UsuariosCentros { get; set; }

        [JsonIgnore]
        public ICollection<UsuarioTutor> UsuariosTutores { get; set; }

        [JsonIgnore]
        public ICollection<Sesion> Sesiones { get; set; }

        public Usuario()
        {
            UsuariosCentros = new List<UsuarioCentro>();
            UsuariosTutores = new List<UsuarioTutor>();
            Sesiones = new List<Sesion>();
        }
    }
}
