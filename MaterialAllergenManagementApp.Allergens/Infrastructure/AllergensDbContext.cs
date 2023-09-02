using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.Infrastructure;

public class AllergensDbContext : DbContext
{
    public static string DefaultSchema = "allergens";

    public DbSet<MaterialAllergenAggregate> MaterialAllergens { get; set; }

    public AllergensDbContext(DbContextOptions<AllergensDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);

        modelBuilder.Entity<MaterialAllergenAggregate>(e =>
        {
            e.Property(b => b.Material).HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<IdNameModel<string>>(v, (JsonSerializerOptions)null));
        });
    }
}