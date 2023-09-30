using FluentAssertions;
using MAM.Allergens.Domain;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.Domain.MaterialClassification;

namespace MAM.Allergens.UnitTests;

public class MaterialTests
{
    private readonly MaterialCode _defaultLegalMaterialCode = MaterialCode.Create("R12345");
    private readonly MaterialName _defaultLegalMaterialName = MaterialName.Create("Short Material Name", "Full Material Name");

    private readonly Stock _defaultLegalStock = Stock.CreateInitialStock(UnitOfMeasure.Create("kg", "Kilogram"), 10);

    private readonly AllergenByNature _emptyAllergenByNature = AllergenByNature.Create(Enumerable.Empty<Allergen>());
    private readonly AllergenByCrossContamination _emptyAllergenByCrossContamination = AllergenByCrossContamination.Create(Enumerable.Empty<Allergen>());
    
    private readonly MaterialType _defaultLegalMaterialType = MaterialType.Create("material_type_id", "Material type name",
        new List<MaterialCategory> { MaterialCategory.RawMaterial }, DateTime.UtcNow);
    
    [Fact]
    public void CreateMaterial_WithNullMaterialType_ThrowsException()
    {
        var action = () => Material.Create(
            _defaultLegalMaterialCode,
            _defaultLegalMaterialName,
            null,
            _defaultLegalStock,
            _emptyAllergenByNature,
            _emptyAllergenByCrossContamination);

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material type is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithEmptyAllergensByNatureAndCrossContaminationLists_CreatesMaterial()
    {
        var material = Material.Create(
            _defaultLegalMaterialCode,
            _defaultLegalMaterialName,
            _defaultLegalMaterialType,
            _defaultLegalStock,
            _emptyAllergenByNature,
            _emptyAllergenByCrossContamination);

        material.IfSucc(m =>
        {
            m.Id.Should().NotBeEmpty();
            m.CreatedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            m.Code.Value.Should().Be(_defaultLegalMaterialCode.Value);
            m.Name.ShortName.Should().Be(_defaultLegalMaterialName.ShortName);
            m.Name.FullName.Should().Be(_defaultLegalMaterialName.FullName);
            m.Type.Should().Be(_defaultLegalMaterialType);
            m.Stock.UnitOfMeasure.Code.Should().Be(_defaultLegalStock.UnitOfMeasure.Code);
            m.Stock.UnitOfMeasure.Name.Should().Be(_defaultLegalStock.UnitOfMeasure.Name);
            m.Stock.CurrentAvailableStock.Should().Be(_defaultLegalStock.CurrentAvailableStock);
            m.AllergensByNature.Allergens.Should().BeEquivalentTo(new List<Allergen>());
            m.AllergensByCrossContamination.Allergens.Should().BeEquivalentTo(new List<Allergen>());
        });
    }    

    [Fact]
    public void CreateMaterial_WithFilledAllergensByNatureAndCrossContaminationLists_CreatesMaterial()
    {
        var allergensByNature = AllergenByNature.Create(new[] { "Wheat", "Soy" }.Select(a => new Allergen(a)));
        var allergensByCrossContamination = AllergenByCrossContamination.Create(new[] { "Nuts", "Soy" }.Select(a => new Allergen(a)));

        var material = Material.Create(
            _defaultLegalMaterialCode,
            _defaultLegalMaterialName,
            _defaultLegalMaterialType,
            _defaultLegalStock,
            allergensByNature,
            allergensByCrossContamination);

        material.IfSucc(m =>
        {
            m.Id.Should().NotBeEmpty();
            m.CreatedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            m.Code.Value.Should().Be(_defaultLegalMaterialCode.Value);
            m.Name.ShortName.Should().Be(_defaultLegalMaterialName.ShortName);
            m.Name.FullName.Should().Be(_defaultLegalMaterialName.FullName);
            m.Type.Should().Be(_defaultLegalMaterialType);
            m.Stock.UnitOfMeasure.Code.Should().Be(_defaultLegalStock.UnitOfMeasure.Code);
            m.Stock.UnitOfMeasure.Name.Should().Be(_defaultLegalStock.UnitOfMeasure.Name);
            m.Stock.CurrentAvailableStock.Should().Be(_defaultLegalStock.CurrentAvailableStock);
            m.AllergensByNature.Allergens.Should().BeEquivalentTo(new List<Allergen> { new ("Wheat"), new ("Soy") });
            m.AllergensByCrossContamination.Allergens.Should().BeEquivalentTo(new List<Allergen> { new ("Soy"), new ("Nuts") });
        });
    } 
}