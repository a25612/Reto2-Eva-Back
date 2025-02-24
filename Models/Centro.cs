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

        [JsonIgnore]
        public ICollection<Empleado> Empleados { get; set; }

        [JsonIgnore]
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }
        
        [JsonIgnore] 
        public ICollection<UsuarioCentro> UsuariosCentros { get; set; }

        public Centro()
        {
            Empleados = new List<Empleado>();
            ServiciosCentros = new List<ServicioCentro>();
        }

        public Centro(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Empleados = new List<Empleado>();
            ServiciosCentros = new List<ServicioCentro>();
        }
    }
}