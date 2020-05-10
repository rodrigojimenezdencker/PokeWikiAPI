using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;
using System.Linq;

namespace PokeWikiAPI.Controllers.BO
{
    public class PokemonBO
    {
        private readonly Context _context;

        public PokemonBO(Context context)
        {
            _context = context;
        }
        public IQueryable<PokemonDTO> getPokemonList()
        {
           return _context.Pokemon.OrderBy(p => p.NumPokedex)
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
                                .Where(pk => pk.PokemonId == p.Prevolution)
                                .Select(pk => new PokemonEvolutionsDTO
                              {
                                  NumPokedex =  pk.NumPokedex,
                                  Name = pk.Name,
                                  Image = pk.Image,
                                  EvolutionRequirements = pk.EvolutionRequirements
                              }).FirstOrDefault(),
                              Evolution = _context.Pokemon
                                .Where(pk => pk.PokemonId == p.Evolution)
                                .Select(pk => new PokemonEvolutionsDTO
                                {
                                    NumPokedex = pk.NumPokedex,
                                    Name = pk.Name,
                                    Image = pk.Image,
                                    EvolutionRequirements = pk.EvolutionRequirements
                              }).FirstOrDefault(),
                              EvolutionRequirements = p.EvolutionRequirements
                          });
        }
    }
}
