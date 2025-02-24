using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UsuarioTutor
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Usuario")]
        public int ID_USUARIO { get; set; }
        public Usuario Usuario { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Tutor")]
        public int ID_TUTOR { get; set; }
        public Tutor Tutor { get; set; }
    }
}