using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RiverBooks.Books;

internal class BookDbContext : DbContext
{
    internal DbSet<Book> Books { get; set; } = default!;

    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Books"); 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}
