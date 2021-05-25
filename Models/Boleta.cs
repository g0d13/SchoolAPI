namespace SchoolAPI.Models
{
    public class Boleta
    {
        public int Id { get; set; }
        public int Faltas { get; set; }
        public int Asistencias { get; set; }
        public int IdCalificacion { get; set; }
        public Calificacion Calificacion { get; set; }
    }
}
