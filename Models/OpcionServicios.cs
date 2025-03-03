using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class OpcionServicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        public int SesionesPorSemana { get; set; }

        public int DuracionMinutos { get; set; }

        [Required]
        public decimal PrecioMensual { get; set; }

        [JsonIgnore]
        public Servicio Servicio { get; set; }
    }
}
