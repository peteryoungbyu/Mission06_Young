using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Young.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options) //Constructor
        {
        }
        public DbSet<MovieEntry> Movies { get; set; }

    }
}
