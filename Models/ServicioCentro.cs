using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ServicioCentro
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Servicio")]
        public int ID_SERVICIO { get; set; }
        public Servicio Servicio { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Centro")]
        public int IdCentro { get; set; }
        public Centros Centro { get; set; }

        // Constructor
        public ServicioCentro() {}

        public ServicioCentro(int idServicio, int idCentro)
        {
            ID_SERVICIO = idServicio;
            IdCentro = idCentro;
        }
    }
}
