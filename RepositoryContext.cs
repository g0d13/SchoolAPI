using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Boleta> Boletas { get; set; }
        public DbSet<Calificacion> Calificacions { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<GradoUsuario> GradoUsuarios { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}