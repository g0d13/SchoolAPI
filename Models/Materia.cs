namespace SchoolAPI.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public int IdGrado { get; set; }
        public Grado Grado { get; set; }
    }
}