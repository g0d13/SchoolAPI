namespace SchoolAPI.Models
{
    public class Maestro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apepat { get; set; }
        public string Apemat { get; set; }
        public int IdGrado { get; set; }
        public Grado Grado { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}