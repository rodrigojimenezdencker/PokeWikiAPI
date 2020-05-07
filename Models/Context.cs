﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Move> Move { get; set; }
        public virtual DbSet<MovePokemon> MovePokemon { get; set; }
        public virtual DbSet<TypePokemon> TypePokemon { get; set; }
    }
}