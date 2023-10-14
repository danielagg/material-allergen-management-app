using MAM.Allergens.Domain;
using MAM.Allergens.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Infrastructure;

public class AllergensDbContext : DbContext
{
    public DbSet<AllergenClassification> AllergenClassifications { get; set; }

    public AllergensDbContext(DbContextOptions<AllergensDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllergenClassification>(e =>
        {
            e.OwnsOne(x => x.ByNatureAllergens, allergen =>
            {
                allergen.Property(a => a.Allergens).HasConversion<AllergenListConverter>();
            });

            e.OwnsOne(x => x.CrossContaminatingAllergens, allergen =>
            {
                allergen.Property(a => a.Allergens).HasConversion<AllergenListConverter>();
            });
        });
    }
}