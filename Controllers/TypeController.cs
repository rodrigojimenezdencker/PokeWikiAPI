using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;

namespace PokeWikiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly Context _context;

        public TypeController(Context context)
        {
            _context = context;
        }

        // GET: api/Type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetType()
        {
            return await _context.Type.ToListAsync();
        }

        // GET: api/Type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Type>> GetType(int id)
        {
            var @type = await _context.Type.FindAsync(id);

            if (@type == null)
            {
                return NotFound();
            }

            return @type;
        }

        // PUT: api/Type/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType(int id, Type @type)
        {
            if (id != @type.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(@type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Type
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Type>> PostType(Type @type)
        {
            _context.Type.Add(@type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = @type.TypeId }, @type);
        }

        // DELETE: api/Type/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Type>> DeleteType(int id)
        {
            var @type = await _context.Type.FindAsync(id);
            if (@type == null)
            {
                return NotFound();
            }

            _context.Type.Remove(@type);
            await _context.SaveChangesAsync();

            return @type;
        }

        private bool TypeExists(int id)
        {
            return _context.Type.Any(e => e.TypeId == id);
        }
    }
}
