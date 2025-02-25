using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Centro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        [JsonIgnore]
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }
        
        [JsonIgnore] 
        public ICollection<UsuarioCentro> UsuariosCentros { get; set; }

        [JsonIgnore]
        public ICollection<EmpleadoCentro> EmpleadosCentros { get; set; }

        public Centro()
        {
            Empleados = new List<Empleado>();
            ServiciosCentros = new List<ServicioCentro>();
            EmpleadosCentros = new List<EmpleadoCentro>();
        }

        public Centro(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Empleados = new List<Empleado>();
            ServiciosCentros = new List<ServicioCentro>();
            EmpleadosCentros = new List<EmpleadoCentro>();
        }
    }
}
