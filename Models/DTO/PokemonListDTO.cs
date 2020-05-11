namespace PokeWikiAPI.Models.DTO
{
    public class PokemonListDTO
    {
        public int NumPokedex { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Types Type1 { get; set; }
        public Types Type2 { get; set; }
    }
}
