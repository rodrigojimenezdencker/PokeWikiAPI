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
    public class MovesController : ControllerBase
    {
        private readonly Context _context;
        private readonly MoveBO moveBO;

        public MovesController(Context context)
        {
            _context = context;
            moveBO = new MoveBO(context);
        }

        // GET: api/Move
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Move>>> GetMove()
        {
            return await _context.Move
                .Include(m => m.Type)
                .ToListAsync();
        }

        // GET: api/Move/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MoveDTO>> GetMove(int id)
        {
            MoveDTO move = await moveBO.getSingleMoveById(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // GET: api/Move/Burbuja
        [HttpGet("{name}")]
        public async Task<ActionResult<MoveDTO>> GetMove(string name)
        {
            MoveDTO move = await moveBO.getSingleMoveByName(name);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // PUT: api/Move/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMove(int id, Move move)
        {
            if (id != move.MoveId)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
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

        // POST: api/Move
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Move>> PostMove(Move move)
        {
            _context.Move.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = move.MoveId }, move);
        }

        // DELETE: api/Move/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Move>> DeleteMove(int id)
        {
            var move = await _context.Move.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Move.Remove(move);
            await _context.SaveChangesAsync();

            return move;
        }

        private bool MoveExists(int id)
        {
            return _context.Move.Any(e => e.MoveId == id);
        }
    }
}
