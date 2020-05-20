using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeWikiAPI.Models.DTO
{
    public class PokemonMovesDTO
    {
        public int MoveId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeImage { get; set; }
        public int Level { get; set; }
    }
}
