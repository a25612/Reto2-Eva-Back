namespace DTOs
{
    public class ActualizarEmpleadoDTO
    {
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public int JornadaTotalHoras { get; set; }
        public List<int> Centro { get; set; }

        public ActualizarEmpleadoDTO()
        {
            Centro = new List<int>();
        }
    }
}
