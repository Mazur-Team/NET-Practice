namespace NETPractice.DAL;


using Microsoft.EntityFrameworkCore;
using Models;


public class CinemaContext : DbContext {
    public DbSet<Movie> Movies { get; set; }

    public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Movie>().HasKey(m => m.Id);
    }
}
