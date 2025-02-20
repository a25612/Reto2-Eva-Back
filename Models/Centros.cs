namespace Models
{
    public class Centros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Centros(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
        }
    }
}