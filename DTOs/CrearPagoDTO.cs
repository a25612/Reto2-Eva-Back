using System.ComponentModel.DataAnnotations;
using static Models.Pago;



namespace DTOs
{
    public class CrearPagoDTO
    {
        [Required]
        public int ID_USUARIO { get; set; }

        [Required]
        public int ID_SESION { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        [EnumDataType(typeof(MetodoPago))]
        public string Metodo_Pago { get; set; }

        [Required]
        public DateTime Fecha_Pago { get; set; }

        [Required]
        [EnumDataType(typeof(EstadoPago))]
        public string Estado { get; set; }
        
    }
}
