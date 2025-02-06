namespace Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public int JornadaTotalHoras { get; set; }
        public string Rol { get; } = "EMPLEADO";

        public Empleado(string nombre, string dni, int jornadaTotalHoras)
        {
            Nombre = nombre;
            DNI = dni;
            JornadaTotalHoras = jornadaTotalHoras;
        }

    }
}
