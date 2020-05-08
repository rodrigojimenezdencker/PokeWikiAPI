using Microsoft.EntityFrameworkCore;

namespace PokeWikiAPI.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Types> Type { get; set; }
        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Move> Move { get; set; }
        public virtual DbSet<MovePokemon> MovePokemon { get; set; }
        public virtual DbSet<TypePokemon> TypePokemon { get; set; }
    }
}
