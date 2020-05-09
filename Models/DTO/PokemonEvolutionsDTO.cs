using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Models.DTO
{
    public class PokemonEvolutionsDTO
    {
        public int NumPokedex { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string EvolutionRequirements { get; set; }
    }
}
