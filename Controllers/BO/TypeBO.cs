using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;
using System.Linq;

namespace PokeWikiAPI.Controllers.BO
{
    public class TypeBO
    {
        private readonly Context _context;

        public TypeBO(Context context)
        {
            _context = context;
        }
        public IQueryable<TypesDTO> getTypesList()
        {
            IQueryable<TypesDTO> TypesQuery = _context.Type
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
                            PokemonId = tp.PokemonId,
                            NumPokedex = tp.Pokemon.NumPokedex,
                            Name = tp.Pokemon.Name,
                            Image = tp.Pokemon.Image
                        }).ToList()
                });

            return TypesQuery;
        }
    }
}
