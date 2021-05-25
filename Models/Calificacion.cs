namespace SchoolAPI.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int Unidad { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdMateria { get; set; }
        public Materia Materia { get; set; }
    }
}