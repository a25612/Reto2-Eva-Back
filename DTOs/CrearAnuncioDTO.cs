using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class CrearAnuncioDTO
    {
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
