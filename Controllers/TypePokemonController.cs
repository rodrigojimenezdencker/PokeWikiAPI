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
    public class TypePokemonController : ControllerBase
    {
        private readonly Context _context;

        public TypePokemonController(Context context)
        {
            _context = context;
        }

        // GET: api/TypePokemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePokemon>>> GetTypePokemon()
        {
            return await _context.TypePokemon.ToListAsync();
        }

        // GET: api/TypePokemon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePokemon>> GetTypePokemon(int id)
        {
            var typePokemon = await _context.TypePokemon.FindAsync(id);

            if (typePokemon == null)
            {
                return NotFound();
            }

            return typePokemon;
        }

        // PUT: api/TypePokemon/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePokemon(int id, TypePokemon typePokemon)
        {
            if (id != typePokemon.TypePokemonId)
            {
                return BadRequest();
            }

            _context.Entry(typePokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePokemonExists(id))
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

        // POST: api/TypePokemon
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypePokemon>> PostTypePokemon(TypePokemon typePokemon)
        {
            _context.TypePokemon.Add(typePokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePokemon", new { id = typePokemon.TypePokemonId }, typePokemon);
        }

        // DELETE: api/TypePokemon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypePokemon>> DeleteTypePokemon(int id)
        {
            var typePokemon = await _context.TypePokemon.FindAsync(id);
            if (typePokemon == null)
            {
                return NotFound();
            }

            _context.TypePokemon.Remove(typePokemon);
            await _context.SaveChangesAsync();

            return typePokemon;
        }

        private bool TypePokemonExists(int id)
        {
            return _context.TypePokemon.Any(e => e.TypePokemonId == id);
        }
    }
}
