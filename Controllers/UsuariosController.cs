using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI;
using SchoolAPI.DataTransferObjects;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(RepositoryContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<IActionResult> PutUsuario(UsuarioDto usuario)
        {
            usuario.Pass = Hash(usuario.Pass);
            var usuarioDb = _mapper.Map<Usuario>(usuario);
            usuarioDb.RolId = (int) usuario.Role;
            _context.Entry(usuarioDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(usuarioDb);
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioDto usuario)
        {
            usuario.Pass = Hash(usuario.Pass);
            var usuarioDb = _mapper.Map<Usuario>(usuario);
            usuarioDb.RolId = (int) usuario.Role;
            await _context.Usuarios.AddAsync(usuarioDb);
            await _context.SaveChangesAsync();
            return Ok(usuarioDb);
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
