namespace SchoolAPI.Models
{
    public class Grado
    {
        public int Id { get; set; }
        public string Grupo { get; set; }
    }

    public class GradoUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get;set; }
        
        public int IdGrado { get; set; }
        public Grado Grado { get; set; }
    }
}