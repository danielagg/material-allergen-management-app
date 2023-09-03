using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MAM.Shared.Domain;
using MAM.Allergens.Domain;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.AllergenClassification;

namespace MAM.Allergens.Infrastructure;

public class AllergensDbContext : DbContext
{
    public static string DefaultSchema = "allergens";

    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }

    public AllergensDbContext(DbContextOptions<AllergensDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);

        modelBuilder.Entity<Material>(e =>
        {
            e.Property(x => x.Identification).HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<IdNameModel<string>>(v, (JsonSerializerOptions)null));

            e.HasOne(x => x.Type);

            e.OwnsOne(x => x.AllergensByNature, allergen => {
                allergen.Property(a => a.Allergens).HasConversion(
                v => string.Join(';', v.Select(vv => vv.Name)),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(a => new Allergen(a)).ToList());
            });
            
            e.OwnsOne(x => x.AllergensByCrossContamination, allergen => {
                allergen.Property(a => a.Allergens).HasConversion(
                v => string.Join(';', v.Select(vv => vv.Name)),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(a => new Allergen(a)).ToList());
            });

            e.OwnsOne(x => x.Stock, stock => {
                stock.OwnsOne(s => s.UnitOfMeasure);
            });
        });

        modelBuilder.Entity<MaterialType>(e =>
        {
            e.Property(x => x.ApplicableFor).HasConversion(
                v => string.Join(";", v.Select(e => e.ToString()).ToArray()),
                v => v.Split(new[] { ';' })
                    .Select(e =>  Enum.Parse(typeof(MaterialCategory), e))
                    .Cast<MaterialCategory>()
                    .ToList()
            );

            e.HasData(new[] {
                MaterialType.Create(
                    "748ca8d1-9eb3-430b-bea5-1e4ddf585815",
                    "Food",
                    new List<MaterialCategory> { MaterialCategory.RawMaterial, MaterialCategory.FinishedGood },
                    new DateTime(2023, 9, 3)),

                MaterialType.Create(
                    "6b8898cc-1ec3-4d7d-bd1c-e4d3890056ee",
                    "Beverage",
                    new List<MaterialCategory> { MaterialCategory.FinishedGood },
                    new DateTime(2023, 9, 3)),

                MaterialType.Create(
                    "c61e1dc8-c257-4796-8423-7815051e0ca6",
                    "Manufacturer Part",
                    new List<MaterialCategory> { MaterialCategory.PackagingMaterial },
                    new DateTime(2023, 9, 3)),

                MaterialType.Create(
                    "2cb9838e-8f77-4217-8558-55874ceef8ce",
                    "Simple Packaging Material",
                    new List<MaterialCategory> { MaterialCategory.PackagingMaterial },
                    new DateTime(2023, 9, 3)),

                MaterialType.Create(
                    "9be1b154-8916-4ee7-9878-c00494fb01f2",
                    "Perishable",
                    new List<MaterialCategory> { MaterialCategory.RawMaterial, MaterialCategory.FinishedGood, MaterialCategory.PackagingMaterial },
                    new DateTime(2023, 9, 3)),
            });
        });
    }
}