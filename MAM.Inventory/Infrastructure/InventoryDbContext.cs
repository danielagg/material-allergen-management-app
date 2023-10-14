using MAM.Inventory.Domain;
using Microsoft.EntityFrameworkCore;

namespace MAM.Inventory.Infrastructure;

public class InventoryDbContext : DbContext
{
    public static string DefaultSchema = "inventory";
    
    public DbSet<Stock> Stocks { get; set; }
    
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);

        modelBuilder.Entity<Stock>(e =>
        {
            e.OwnsOne(x => x.UnitOfMeasure);
        });
    }
}


