namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string CodigoFacturacion { get; set; }
        public List<CentroDTO> Centros { get; set; } 
    }

    public class CentroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
