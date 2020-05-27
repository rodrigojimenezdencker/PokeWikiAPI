namespace PokeWikiAPI.Models.DTO
{
    public class MoveListDTO
    {
        public int MoveId { get; set; }
        public string Name { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public int  Quantity { get; set; }
        public Types Type { get; set; }
    }
}
