using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Controllers.BO
{
    public class MoveBO
    {
        private readonly Context _context;

        public MoveBO(Context context)
        {
            _context = context;
        }
        public async Task<MoveDTO> getSingleMove(int id)
        {
            return await _context.Move
                .Where(m => m.MoveId == id)
                .Select(m => new MoveDTO
                {
                    Name = m.Name,
                    Description = m.Description,
                    Power = m.Power,
                    Accuracy = m.Accuracy,
                    Quantity = m.Quantity,
                    Type = m.Type.Name,
                    Pokemons = _context.MovePokemon
                       .Include(mp => mp.Pokemon)
                       .Where(mp => mp.Pokemon.PokemonId == mp.PokemonId && mp.MoveId == m.MoveId)
                       .Select(mp => new PokemonListDTO
                       {
                           NumPokedex = mp.Pokemon.NumPokedex,
                           Name = mp.Pokemon.Name,
                           Image = mp.Pokemon.Image
                       }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
