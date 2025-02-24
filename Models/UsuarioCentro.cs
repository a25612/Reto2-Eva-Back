namespace Models
{
    public class UsuarioCentro
    {
        public int ID_USUARIO { get; set; }
        public Usuario Usuario { get; set; }

        public int ID_CENTRO { get; set; }
        public Centro Centro { get; set; }
    }
}
