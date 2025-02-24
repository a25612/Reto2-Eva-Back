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

        [JsonIgnore] 
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }

        public ICollection<Sesion> Sesiones { get; set; }

        public Servicio() {}
        public Servicio(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            ServiciosCentros = new List<ServicioCentro>();
            Sesiones = new List<Sesion>();
        }
    }
}
