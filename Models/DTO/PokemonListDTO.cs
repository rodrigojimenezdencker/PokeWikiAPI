using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Models.DTO
{
    public class PokemonListDTO
    {
        public int PokemonId { get; set; }
        public int NumPokedex { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
