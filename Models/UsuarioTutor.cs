using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UsuarioTutor
    {
        [Key]
        public int Id { get; set; } 

        [ForeignKey("Usuario")]
        public int ID_USUARIO { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Tutor")]
        public int ID_TUTOR { get; set; }
        public Tutor Tutor { get; set; }
    }
}
