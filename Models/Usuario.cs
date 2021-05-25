namespace SchoolAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Iae { get; set; }
        public string Nombre { get; set; }
        public string Apepat { get; set; }
        public string Apemat { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Pass { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}