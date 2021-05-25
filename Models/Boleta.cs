namespace SchoolAPI.Models
{
    public class Boleta
    {
        public int Id { get; set; }
        public int Faltas { get; set; }
        public int Asistencias { get; set; }
        public int CalificacionId { get; set; }
        public Calificacion Calificacion { get; set; }
    }
}
