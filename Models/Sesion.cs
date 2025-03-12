using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Sesion
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime FECHA { get; set; }

        [ForeignKey("Usuario")]
        public int USUARIOID { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Tutor")]
        public int ID_TUTOR { get; set; }
        public Tutor Tutor { get; set; }

        [ForeignKey("Empleado")]
        public int ID_EMPLEADO { get; set; }
        public Empleado Empleado { get; set; }

        [ForeignKey("Servicio")]
        public int SERVICIOID { get; set; }
        public Servicio Servicio { get; set; }

        [ForeignKey("OpcionServicio")]
        public int? ID_OPCION_SERVICIO { get; set; }
        public OpcionServicio OpcionServicio { get; set; }

        [ForeignKey("Centro")]
        public int ID_CENTRO { get; set; }
        public Centro Centro { get; set; }

        [Required]
        public bool FACTURAR { get; set; } 
    }
}
