//Context file for the database

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Young.Models
{
    public class MovieEntryContext : DbContext //Context class
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options) //Constructor for the class
        {
        }
        public DbSet<MovieEntry> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
