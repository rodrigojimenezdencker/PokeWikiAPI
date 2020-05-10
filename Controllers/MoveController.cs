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
    public class MoveController : ControllerBase
    {
        private readonly Context _context;

        public MoveController(Context context)
        {
            _context = context;
        }

        // GET: api/Move
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoveDTO>>> GetMove()
        {
            MoveBO moveBO = new MoveBO(_context);
            IQueryable<MoveDTO> MoveQuery = moveBO.getMoveList();

            return await MoveQuery.ToListAsync();
        }

        // GET: api/Move/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> GetMove(int id)
        {
            var move = await _context.Move.FindAsync(id);

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
