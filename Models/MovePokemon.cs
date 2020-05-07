using System.ComponentModel.DataAnnotations;

namespace PokeWikiAPI.Models
{
    public class MovePokemon
    {
        [Required]
        [Key]
        public int MovePokemonId { get; set; }
        [Required]
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
        [Required]
        public int MoveId { get; set; }
        public Move Move { get; set; }
        [Required]
        public int Level { get; set; }
    }
}
