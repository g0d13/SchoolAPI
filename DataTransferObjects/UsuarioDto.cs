namespace SchoolAPI.DataTransferObjects
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Iae { get; set; }
        public string Nombre { get; set; }
        public string Apepat { get; set; }
        public string Apemat { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Pass { get; set; }
        public int Role { get; set; }
    }
}