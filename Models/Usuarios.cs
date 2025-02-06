namespace Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string CodigoFacturacion { get; set; }
        public Usuario(string nombre, string dni, string codigoFacturacion)
        {
            Nombre = nombre;
            DNI = dni;
            CodigoFacturacion = codigoFacturacion;
        }

    }
}