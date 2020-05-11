using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Controllers.BO
{
    public class TypeBO
    {
        private readonly Context _context;

        public TypeBO(Context context)
        {
            _context = context;
        }
        public async Task<TypesDTO> getSingleType(int id)
        {
            return await _context.Type
                .Where(t => t.TypeId == id)
                .Select(t => new TypesDTO
                {
                    Name = t.Name,
                    Color = t.Color,
                    Image = t.Image,
                    SecondaryImage = t.SecondaryImage,
                    Pokemons = _context.TypePokemon
                        .Include(tp => tp.Pokemon)
                        .Where(tp => tp.Pokemon.PokemonId == tp.PokemonId && tp.TypeId == t.TypeId)
                        .Select(tp => new PokemonListDTO
                        {
                            NumPokedex = tp.Pokemon.NumPokedex,
                            Name = tp.Pokemon.Name,
                            Image = tp.Pokemon.Image
                        }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
