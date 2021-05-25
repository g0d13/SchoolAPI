using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradosController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public GradosController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Grados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grado>>> GetGrados()
        {
            return await _context.Grados.ToListAsync();
        }

        // GET: api/Grados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grado>> GetGrado(int id)
        {
            var grado = await _context.Grados.FindAsync(id);

            if (grado == null)
            {
                return NotFound();
            }

            return grado;
        }

        // PUT: api/Grados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado(int id, Grado grado)
        {
            if (id != grado.Id)
            {
                return BadRequest();
            }

            _context.Entry(grado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Grados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grado>> PostGrado(Grado grado)
        {
            _context.Grados.Add(grado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrado", new { id = grado.Id }, grado);
        }

        // DELETE: api/Grados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrado(int id)
        {
            var grado = await _context.Grados.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }

            _context.Grados.Remove(grado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradoExists(int id)
        {
            return _context.Grados.Any(e => e.Id == id);
        }
    }
}
