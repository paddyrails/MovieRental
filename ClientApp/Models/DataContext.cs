using Microsoft.EntityFrameworkCore;

namespace DVDMovie.Models{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Movie> Studios {get; set;}
        public DbSet<Movie> Ratings {get; set;}
    }
}