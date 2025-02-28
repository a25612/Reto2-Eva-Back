using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Anuncio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string ImagenUrl { get; set; }

        public DateTime FechaPublicacion { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;
    }
}
