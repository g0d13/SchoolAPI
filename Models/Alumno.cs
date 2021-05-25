namespace SchoolAPI.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Iae { get; set; }
        public string Direccion { get; set; }
        
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}