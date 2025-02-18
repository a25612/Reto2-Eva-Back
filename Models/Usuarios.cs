namespace Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string CodigoFacturacion { get; set; }
        public Usuario(int id, string nombre, string dni, string codigoFacturacion)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            CodigoFacturacion = codigoFacturacion;
        }

    }
}