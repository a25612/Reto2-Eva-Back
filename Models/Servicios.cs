namespace Models
{

    public class Servicio
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
        public Servicio(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
