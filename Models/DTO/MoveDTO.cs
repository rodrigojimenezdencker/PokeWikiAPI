﻿using System.Collections.Generic;

namespace PokeWikiAPI.Models.DTO
{
    public class MoveDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public List<PokemonListDTO> Pokemons { get; set; }
    }
}
