using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class CrearSesionDTO
    {
        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public int IdCentro { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int IdOpcionServicio { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdTutor { get; set; }
    }
}
