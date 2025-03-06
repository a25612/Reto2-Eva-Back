using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Anuncio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime Fecha_Publicacion { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;
    }
}
