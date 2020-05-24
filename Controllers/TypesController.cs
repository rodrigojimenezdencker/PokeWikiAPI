using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Controllers.BO;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;

namespace PokeWikiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly Context _context;
        private readonly TypeBO typeBO;

        public TypesController(Context context)
        {
            _context = context;
            typeBO = new TypeBO(context);
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Types>>> GetTypes()
        {
            return await _context.Type.OrderBy(t => t.TypeId).ToListAsync();
        }

        // GET: api/Types/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TypesDTO>> GetTypes(int id)
        {
            TypesDTO type = await typeBO.getSingleTypeById(id);

            if (type == null)
            {
                return NotFound();
            }

            return type;
        }

        // GET: api/Types/agua
        [HttpGet("{name}")]
        public async Task<ActionResult<TypesDTO>> GetTypes(string name)
        {
            TypesDTO type = await typeBO.getSingleTypeByName(name);

            if (type == null)
            {
                return NotFound();
            }

            return type;
        }

        // PUT: api/Types/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypes(int id, Types types)
        {
            if (id != types.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesExists(id))
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

        // POST: api/Types
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Types>> PostTypes(Types types)
        {
            _context.Type.Add(types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypes", new { id = types.TypeId }, types);
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Types>> DeleteTypes(int id)
        {
            var types = await _context.Type.FindAsync(id);
            if (types == null)
            {
                return NotFound();
            }

            _context.Type.Remove(types);
            await _context.SaveChangesAsync();

            return types;
        }

        private bool TypesExists(int id)
        {
            return _context.Type.Any(e => e.TypeId == id);
        }
    }
}
