using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class ActualizarAnuncioDTO
    {
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}