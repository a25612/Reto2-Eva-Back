using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int ID_USUARIO { get; set; }
        
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [ForeignKey("Sesion")]
        public int ID_SESION { get; set; }

        [JsonIgnore]
        public Sesion Sesion { get; set; }

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


        public enum MetodoPago

        {
            Efectivo,
            Tarjeta,
            Transferencia,
            PayPal
        }

        public enum EstadoPago
        {
            Pendiente,
            Completado,
            Cancelado
        }




    }
}