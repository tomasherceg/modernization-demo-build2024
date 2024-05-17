using Microsoft.EntityFrameworkCore;

namespace Modernization.BackendApi.Data;

public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.OwnsMany(p => p.Prices);
        });

        base.OnModelCreating(modelBuilder);
    }
}