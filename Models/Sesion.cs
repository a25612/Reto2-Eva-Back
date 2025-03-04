using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Sesion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")]
        public int ID_USUARIO { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Empleado")]
        public int ID_EMPLEADO { get; set; }
        public Empleado Empleado { get; set; }

        [ForeignKey("Servicio")]
        public int ID_SERVICIO { get; set; }
        public Servicio Servicio { get; set; }

        [ForeignKey("Centro")]
        public int ID_CENTRO { get; set; }
        public Centro Centro { get; set; }

        [Required]
        public bool Facturar { get; set; }

        public Sesion() { }

        public Sesion(DateTime fecha, int idUsuario, int idEmpleado, int idServicio, int idCentro, bool facturar)
        {
            Fecha = fecha;
            ID_USUARIO = idUsuario;
            ID_EMPLEADO = idEmpleado;
            ID_SERVICIO = idServicio;
            ID_CENTRO = idCentro;
            Facturar = facturar;
        }
    }
}
