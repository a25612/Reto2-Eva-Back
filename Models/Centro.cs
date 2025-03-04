using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Centro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        // Relación muchos a muchos con Empleados
        [JsonIgnore]
        public ICollection<EmpleadosCentros> EmpleadosCentros { get; set; }

        // Relación muchos a muchos con Servicios
        [JsonIgnore]
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }

        // Relación muchos a muchos con Usuarios
        [JsonIgnore]
        public ICollection<UsuarioCentro> UsuariosCentros { get; set; }

        public Centro()
        {
            EmpleadosCentros = new List<EmpleadosCentros>();
            ServiciosCentros = new List<ServicioCentro>();
            UsuariosCentros = new List<UsuarioCentro>();
        }

        public Centro(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            EmpleadosCentros = new List<EmpleadosCentros>();
            ServiciosCentros = new List<ServicioCentro>();
            UsuariosCentros = new List<UsuarioCentro>();
        }
    }
}