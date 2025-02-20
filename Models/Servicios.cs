using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Relación con Centros (N:N)
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }

        // Relación con Sesiones
        public ICollection<Sesiones> Sesiones { get; set; }

        // Constructor vacío (necesario para EF Core)
        public Servicio() {}

        // Constructor completo
        public Servicio(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            ServiciosCentros = new List<ServicioCentro>();
            Sesiones = new List<Sesiones>();
        }
    }
}
