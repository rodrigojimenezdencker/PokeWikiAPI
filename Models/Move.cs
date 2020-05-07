using System.ComponentModel.DataAnnotations;

namespace PokeWikiAPI.Models
{
    public class Move
    {
        [Required]
        [Key]
        public int MoveId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
