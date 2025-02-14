namespace Models
{
    public class Tutor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public string Rol { get; } = "TUTOR";
        public Tutor(int id, string nombre, string dni, string email, string username, string password, bool activo = true)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            Email = email;
            Username = username;
            Password = password;
            Activo = activo;
        }
    }
}
