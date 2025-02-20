using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Centro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; }

        // Relación con Empleados (1:N)
        public ICollection<Empleado> Empleados { get; set; }

        // Relación con Servicios (N:N a través de ServicioCentro)
        public ICollection<ServicioCentro> ServiciosCentros { get; set; }

        // Constructor vacío (necesario para EF Core)
        public Centro()
        {
            Empleados = new List<Empleado>();
            ServiciosCentros = new List<ServicioCentro>();
        }

        // Constructor completo
        public Centro(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Empleados = new List<Empleado>();
            ServiciosCentros = new List<ServicioCentro>();
        }
    }
}
