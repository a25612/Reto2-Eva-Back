using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Sesiones
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime FECHA { get; set; }

        [ForeignKey("Usuario")]
        public int ID_USUARIO { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Empleado")]
        public int ID_EMPLEADO { get; set; }
        public Empleado Empleado { get; set; }

        [ForeignKey("Servicio")]
        public int ID_SERVICIO { get; set; }
        public Servicio Servicio { get; set; }

        [Required]
        public string FACTURAR { get; set; } // 'S' o 'N'

        // Constructor
        public Sesiones()
        {
            FECHA = DateTime.Now;
            FACTURAR = "N"; // Valor predeterminado
        }

        public Sesiones(DateTime fecha, int idUsuario, int idEmpleado, int idServicio, string facturar)
        {
            FECHA = fecha;
            ID_USUARIO = idUsuario;
            ID_EMPLEADO = idEmpleado;
            ID_SERVICIO = idServicio;
            FACTURAR = facturar;
        }
    }
}
