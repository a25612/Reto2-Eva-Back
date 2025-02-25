using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class EmpleadoCentro
    {
        [Key, Column(Order = 0)]
        public int ID_EMPLEADO { get; set; }

        [Key, Column(Order = 1)]
        public int ID_CENTRO { get; set; }

        [ForeignKey("ID_EMPLEADO")]
        public Empleado Empleado { get; set; }

        [ForeignKey("ID_CENTRO")]
        public Centro Centro { get; set; }
    }
}
