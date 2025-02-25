using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class EmpleadosCentros
    {
        public int ID_EMPLEADO { get; set; }
        public int ID_CENTRO { get; set; }

        // Relaciones de navegación
        [ForeignKey("ID_EMPLEADO")]
        public Empleado Empleado { get; set; }

        [ForeignKey("ID_CENTRO")]
        public Centro Centro { get; set; }
    }
}
