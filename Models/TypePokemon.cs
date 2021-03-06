﻿using System.ComponentModel.DataAnnotations;

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
        public Types Type { get; set; }
        [Required]
        public bool Subtype { get; set; }
    }
}
