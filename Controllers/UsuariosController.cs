using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.DataTransferObjects;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public UsuariosController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.Include(us => us.Rol).ToListAsync();
        }
        
        private string Hash(string texto)
        {
            using(SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] stringTemp = System.Text.Encoding.UTF8.GetBytes(texto);
                var hash = sha1.ComputeHash(stringTemp);
                return Convert.ToBase64String(hash);
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUsuario(Usuario usuario)
        {
            usuario.Pass = Hash(usuario.Pass);
            var rol = await _context.Roles.FindAsync(usuario.RolId);
            if (rol == null)
            {
                return NotFound(new {Mensaje = "No existe el rol"});
            }
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var tmpUser = await _context.Usuarios
                .Where(u => u.Correo == usuario.Correo || u.Iae == usuario.Iae)
                .FirstOrDefaultAsync();
            if (tmpUser != null)
            {
                return Conflict(new {Mensaje = "El correo ya existe"});
            }
            usuario.Pass = Hash(usuario.Pass);
            var rol = await _context.Roles.FindAsync(usuario.RolId);
            if (rol == null)
            {
                return NotFound(new {Mensaje = "No existe el rol"});
            }
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
