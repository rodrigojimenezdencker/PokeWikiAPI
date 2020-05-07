using System.ComponentModel.DataAnnotations;

namespace PokeWikiAPI.Models
{
    public class Type
    {
        [Required]
        [Key]
        public int TypeId { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15)]
        public string Color { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string SecondaryImage { get; set; }
    }
}
