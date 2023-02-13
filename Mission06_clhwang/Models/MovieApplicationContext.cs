using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_clhwang.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base (options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<ApplicationResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    Category = "Romantic Comedy",
                    Title = "A Cinderella Story",
                    Year = 2004,
                    Director = "Mark Rosman",
                    Rating = "PG",
                    Edited = false,
                    Notes = "This is my go-to movie."
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    Category = "Action/Adventure",
                    Title = "Avengers: Endgame",
                    Year = 2019,
                    Director = "Joe Russo",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    Category = "Romantic Comedy",
                    Title = "10 Things I Hate About You",
                    Year = 1999,
                    Director = "Gil Junger",
                    Rating = "PG-13",
                    Edited = false,
                    Notes = "This is a classic."
                }
            );
        }
    }
}
