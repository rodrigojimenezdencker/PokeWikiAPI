using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeWikiAPI;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;

namespace PokeWikiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly Context _context;

        public PokemonController(Context context)
        {
            _context = context;
        }

        // GET: api/Pokemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemon()
        {
            var PokemonQuery = _context.Pokemon.OrderBy(p => p.NumPokedex)
                          .Select(p => new PokemonDTO
                          {
                              NumPokedex = p.NumPokedex,
                              Name = p.Name,
                              Description = p.Description,
                              Type1 = _context.TypePokemon
                                .Include(tp => tp.Type)
                                .Where(t => p.PokemonId == t.PokemonId && !t.Subtype)
                                .Select(t => t.Type).FirstOrDefault(), 
                              Type2 = _context.TypePokemon
                                .Include(tp => tp.Type)
                                .Where(t => p.PokemonId == t.PokemonId && t.Subtype)
                                .Select(t => t.Type).FirstOrDefault(),
                              Ability = p.Ability,
                              SecondaryAbility = p.SecondaryAbility,
                              HiddenAbility = p.HiddenAbility,
                              Image = p.Image,
                              Weight = p.Weight,
                              Height = p.Height,
                              PS = p.PS,
                              Attack = p.Attack,
                              Defense = p.Defense,
                              SpAttack = p.SpAttack,
                              SpDefense = p.SpDefense,
                              Speed = p.Speed,
                              Prevolution = _context.Pokemon
                                .Where(t => t.PokemonId == p.Prevolution)
                                .Select(t => t).FirstOrDefault(),
                              Evolution = _context.Pokemon
                                .Where(t=> t.PokemonId == p.Evolution)
                                .Select(t => t).FirstOrDefault(),
                              EvolutionRequirements = p.EvolutionRequirements
                          });

            return await PokemonQuery.ToListAsync();
        }

        // GET: api/Pokemon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // PUT: api/Pokemon/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemon(int id, Pokemon pokemon)
        {
            if (id != pokemon.PokemonId)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
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

        // POST: api/Pokemon
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokemon", new { id = pokemon.PokemonId }, pokemon);
        }

        // DELETE: api/Pokemon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pokemon>> DeletePokemon(int id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();

            return pokemon;
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(e => e.PokemonId == id);
        }
    }
}
