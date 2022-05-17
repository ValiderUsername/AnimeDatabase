using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnimeDatabase.Data;
using System;
using System.Linq;

namespace AnimeDatabase.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AnimeDatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AnimeDatabaseContext>>()))
            {
                // Look for any movies.
                if (context.Animeliste.Any())
                {
                    return;   // DB has been seeded
                }

                context.Animeliste.AddRange(
                    new Animeliste
                    {
                        Title = "Konosuba Season 1",
                        Genre = "Isekai",
                        Episoden = 12,
                        ReleaseDate = DateTime.Parse("2016-7-23"),
                    },

                    new Animeliste
                    {
                        Title = "ReZero Season 1 ",
                        Genre = "Isekai",
                        Episoden = 24,
                        ReleaseDate = DateTime.Parse("2015-3-13"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}