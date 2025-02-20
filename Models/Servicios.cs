namespace Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public List<int> IdsCentros { get; set; }

        public Servicio(int id, string nombre, decimal precio, List<int> idsCentros)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            IdsCentros = idsCentros;
        }
    }
}
