
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<ComicBook> ComicBooks { get; set; }
    public DbSet<StoreLocation> StoreLocations { get; set; }
}
