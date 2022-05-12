using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimeDatabase.Models;

namespace AnimeDatabase.Data
{
    public class AnimeDatabaseContext : DbContext
    {
        public AnimeDatabaseContext (DbContextOptions<AnimeDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<AnimeDatabase.Models.Animeliste>? Animeliste { get; set; }

        public DbSet<AnimeDatabase.Models.Characterliste>? Characterliste { get; set; }
    }
}
