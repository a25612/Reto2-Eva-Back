namespace Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public int JornadaTotalHoras { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; } = "EMPLEADO";

        public Empleado(int id, string nombre, string dni, int jornadaTotalHoras, string username, string password)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            JornadaTotalHoras = jornadaTotalHoras;
            Username = username;
            Password = password;
        }
    }
}
