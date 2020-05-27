using System.Collections.Generic;

namespace PokeWikiAPI.Models.DTO
{
    public class TypesDTO
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string SecondaryImage { get; set; }
        public List<PokemonListDTO> Pokemons { get; set; }
        public List<MoveListDTO> Moves { get; set; }
    }
}
