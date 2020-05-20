using System.Collections.Generic;

namespace PokeWikiAPI.Models.DTO
{
    public class PokemonDTO
    {
        public int NumPokedex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Types Type1 { get; set; }
        public Types Type2 { get; set; }
        public string Ability { get; set; }
        public string SecondaryAbility { get; set; }
        public string HiddenAbility { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public int PS { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public PokemonEvolutionsDTO Prevolution { get; set; }
        public PokemonEvolutionsDTO Evolution { get; set; }
        public string EvolutionRequirements { get; set; }
        public ICollection<PokemonMovesDTO> Moves { get; set; }
    }
}