namespace Models
{

    public class Servicio
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
        public Servicio(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }
    }
}
