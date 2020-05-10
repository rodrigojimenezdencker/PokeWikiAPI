using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;
using System.Linq;

namespace PokeWikiAPI.Controllers.BO
{
    public class MoveBO
    {
        private readonly Context _context;

        public MoveBO(Context context)
        {
            _context = context;
        }

        public IQueryable<MoveDTO> getMoveList()
        {
            IQueryable<MoveDTO> MoveQuery = _context.Move
                .Include(m => m.Type)
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
                       .Select(tp => new PokemonListDTO
                       {
                           PokemonId = tp.PokemonId,
                           NumPokedex = tp.Pokemon.NumPokedex,
                           Name = tp.Pokemon.Name,
                           Image = tp.Pokemon.Image
                       }).ToList()
                });
            return MoveQuery;
        }
    }
}
