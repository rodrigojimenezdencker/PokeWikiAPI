using System.ComponentModel.DataAnnotations;

namespace PokeWikiAPI
{
    public class Pokemon
    {
        [Required]
        [Key]
        public int PokemonId { get; set; }
        [Required]
        public int NumPokedex { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ability { get; set; }
        [MaxLength(50)]
        public string SecondaryAbility { get; set; }
        [MaxLength(50)]
        public string HiddenAbility { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int PS { get; set; }
        [Required]
        public int Attack { get; set; }
        [Required]
        public int Defense { get; set; }
        [Required]
        public int SpAttack { get; set; }
        [Required]
        public int SpDefense { get; set; }
        [Required]
        public int Speed { get; set; }
        public int? Prevolution { get; set; }
        public int? Evolution { get; set; }
        [MaxLength(35)]
        public string EvolutionRequirements { get; set; }
    }
}
