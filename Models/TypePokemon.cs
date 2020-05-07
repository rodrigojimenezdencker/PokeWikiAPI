using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Models
{
    public class TypePokemon
    {
        [Required]
        [Key]
        public int TypePokemonId { get; set; }
        [Required]
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
        [Required]
        public int TypeId { get; set; }
        public Type Type { get; set; }
        [Required]
        public bool Subtype { get; set; }
    }
}
