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
        public int UsuarioId { get; set; }
        public Usuario Usuario { get;set; }
        
    }
}