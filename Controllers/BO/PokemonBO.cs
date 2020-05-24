using Microsoft.EntityFrameworkCore;
using PokeWikiAPI.Models;
using PokeWikiAPI.Models.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Controllers.BO
{
    public class PokemonBO
    {
        private readonly Context _context;

        public PokemonBO(Context context)
        {
            _context = context;
        }
        public IQueryable<PokemonListDTO> getPokemonList()
        {
           return _context.Pokemon
                .OrderBy(p => p.NumPokedex)
                .Select(p => new PokemonListDTO
                {
                    PokemonId = p.PokemonId,
                    NumPokedex = p.NumPokedex,
                    Name = p.Name,
                    Image = p.Image,
                    Type1 = _context.TypePokemon
                        .Include(tp => tp.Type)
                        .Where(tp => tp.PokemonId == p.NumPokedex && tp.TypeId == tp.Type.TypeId && !tp.Subtype)
                        .Select(tp => tp.Type).FirstOrDefault(),
                    Type2 = _context.TypePokemon
                        .Include(tp => tp.Type)
                        .Where(tp => tp.PokemonId == p.NumPokedex && tp.TypeId == tp.Type.TypeId && tp.Subtype)
                        .Select(tp => tp.Type).FirstOrDefault()
                });
        }
        public async Task<PokemonDTO> getSinglePokemonById(int id)
        {
            return await _context.Pokemon.OrderBy(p => p.NumPokedex)
                .Where(p => p.NumPokedex == id)
                .Select(p => new PokemonDTO
                {
                    PokemonId = p.PokemonId,
                    NumPokedex = p.NumPokedex,
                    Name = p.Name,
                    Description = p.Description,
                    Type1 = _context.TypePokemon
                    .Include(tp => tp.Type)
                    .Where(t => p.NumPokedex == t.PokemonId && !t.Subtype)
                    .Select(t => t.Type).FirstOrDefault(),
                    Type2 = _context.TypePokemon
                    .Include(tp => tp.Type)
                    .Where(t => p.NumPokedex == t.PokemonId && t.Subtype)
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
                        NumPokedex = pk.NumPokedex,
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
                    EvolutionRequirements = p.EvolutionRequirements,
                    Moves = _context.MovePokemon
                    .Include(mp => mp.Move)
                    .Where(mp => mp.PokemonId == p.PokemonId)
                    .Select(mp => new PokemonMovesDTO
                    {
                        MoveId = mp.Move.MoveId,
                        Name = mp.Move.Name,
                        TypeId = _context.Type.Where(t => mp.Move.TypeId == t.TypeId).Select(t => t.TypeId).FirstOrDefault(),
                        TypeName = _context.Type.Where(t => mp.Move.TypeId == t.TypeId).Select(t => t.Name).FirstOrDefault(),
                        TypeImage = _context.Type.Where(t => mp.Move.TypeId == t.TypeId).Select(t => t.SecondaryImage).FirstOrDefault(),
                        Level = mp.Level
                    }).ToList()
                }).FirstAsync();
        }

        public async Task<PokemonDTO> getSinglePokemonByName(string name)
        {
            return await _context.Pokemon.OrderBy(p => p.NumPokedex)
                .Where(p => p.Name.ToLower() == name.ToLower())
                .Select(p => new PokemonDTO
                {
                    PokemonId = p.PokemonId,
                    NumPokedex = p.NumPokedex,
                    Name = p.Name,
                    Description = p.Description,
                    Type1 = _context.TypePokemon
                    .Include(tp => tp.Type)
                    .Where(t => p.NumPokedex == t.PokemonId && !t.Subtype)
                    .Select(t => t.Type).FirstOrDefault(),
                    Type2 = _context.TypePokemon
                    .Include(tp => tp.Type)
                    .Where(t => p.NumPokedex == t.PokemonId && t.Subtype)
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
                        NumPokedex = pk.NumPokedex,
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
                    EvolutionRequirements = p.EvolutionRequirements,
                    Moves = _context.MovePokemon
                    .Include(mp => mp.Move)
                    .Where(mp => mp.PokemonId == p.PokemonId)
                    .Select(mp => new PokemonMovesDTO
                    {
                        MoveId = mp.Move.MoveId,
                        Name = mp.Move.Name,
                        TypeId = _context.Type.Where(t => mp.Move.TypeId == t.TypeId).Select(t => t.TypeId).FirstOrDefault(),
                        TypeName = _context.Type.Where(t => mp.Move.TypeId == t.TypeId).Select(t => t.Name).FirstOrDefault(),
                        TypeImage = _context.Type.Where(t => mp.Move.TypeId == t.TypeId).Select(t => t.Image).FirstOrDefault(),
                        Level = mp.Level
                    }).ToList()
                }).FirstAsync();
        }
    }
}
