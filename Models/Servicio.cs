using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public string Descripcion {get; set;}

        [JsonIgnore]
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }

        [JsonIgnore] 
        public ICollection<Sesion> Sesiones { get; set; }

        public Servicio()
        {
            ServiciosCentros = new List<ServicioCentro>();
            Sesiones = new List<Sesion>();
        }
    }
}
