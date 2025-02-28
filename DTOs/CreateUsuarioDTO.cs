namespace DTOs
{
    public class CreateUsuario
    {
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string CodigoFacturacion { get; set; }
        public int IdCentro { get; set; }
        public List<string> NombresTutores { get; set; } = new List<string>();
    }
}
