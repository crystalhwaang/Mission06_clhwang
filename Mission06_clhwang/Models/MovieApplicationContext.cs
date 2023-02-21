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
        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
            
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 4,
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
                    CategoryId = 1,
                    Title = "Avengers: Endgame",
                    Year = 2019,
                    Director = "Joe Russo",
                    Rating = "PG-13",
                    Edited = false
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryId = 3,
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
