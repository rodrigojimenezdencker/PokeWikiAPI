namespace PokeWikiAPI.Models.DTO
{
    public class PokemonEvolutionsDTO
    {
        public int NumPokedex { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string EvolutionRequirements { get; set; }
        public PokemonEvolutionsDTO Prevolution { get; set; }
        public PokemonEvolutionsDTO Evolution { get; set; }
    }
}
