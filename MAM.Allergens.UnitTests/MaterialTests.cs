using FluentAssertions;
using MAM.Allergens.Domain;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.Inventory;

namespace MAM.Allergens.UnitTests;

public class MaterialTests
{
    private readonly MaterialType DefaultMaterialType = MaterialType.Create("material_type_id", "Material type name",
        new List<MaterialCategory> { MaterialCategory.RawMaterial }, DateTime.UtcNow);

    [Theory]
    [InlineData(null, "Material code cannot be empty")]
    [InlineData("", "Material code cannot be empty")]
    [InlineData("12345", "Material code must be 6 characters long")]
    [InlineData("1234567", "Material code must be 6 characters long")]
    [InlineData("T23456", "Material code must start with P or R")]
    public void CreateMaterialCode_WithIllegalFormattedMaterialId_ThrowsException(string materialCode, string expectedExceptionMessage)
    {
        var action = () => MaterialCode.Create(materialCode);

        action
            .Should()
            .Throw<InvalidMaterialCodeException>()
            .WithMessage(expectedExceptionMessage);
    }

    [Theory]
    [InlineData("R12345")]
    [InlineData("P12345")]
    [InlineData(" P12345 ")]
    public void CreateMaterialCode_WithLegalValue_CreatesAndTrimsMaterialCode(string materialCode)
    {
        var result = MaterialCode.Create(materialCode);
        result.Value.Should().Be(materialCode.Trim());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateUnitOfMeasure_WithIllegalCode_ThrowsException(string unitOfMeasureCode)
    {
        var action = () => UnitOfMeasure.Create(unitOfMeasureCode, "kilogram");

        action
            .Should()
            .Throw<InvalidUnitOfMeasureException>()
            .WithMessage("Unit of measure code is mandatory");
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateUnitOfMeasure_WithIllegalName_ThrowsException(string unitOfMeasureName)
    {
        var action = () => UnitOfMeasure.Create("kg", unitOfMeasureName);

        action
            .Should()
            .Throw<InvalidUnitOfMeasureException>()
            .WithMessage("Unit of measure name is mandatory");
    }

    [Theory]
    [InlineData("kg", "Kilogram")]
    [InlineData(" l ", " Liter ")]
    public void CreateUnitOfMeasure_WithLegalValues_CreatesUnitOfMeasureAndTrimsValues(string unitOfMeasureCode, string unitOfMeasureName)
    {
        var result = UnitOfMeasure.Create(unitOfMeasureCode, unitOfMeasureName);
        result.Code.Should().Be(unitOfMeasureCode.Trim());
        result.Name.Should().Be(unitOfMeasureName.Trim());
    }

    [Fact]
    public void CreateStock_WithoutUnitOfMeasure_ThrowsException()
    {
        var action = () => Stock.CreateInitialStock(null, 10);

        action
            .Should()
            .Throw<MissingUnitOfMeasureException>()
            .WithMessage("Initial stock must have a unit of measure");        
    }    

    [Fact]
    public void CreateStock_WithNegativeValue_ThrowsException()
    {
        var unitOfMeasure = UnitOfMeasure.Create("kg", "Kilogram");

        var action = () => Stock.CreateInitialStock(unitOfMeasure, -1);

        action
            .Should()
            .Throw<InvalidInitialStockException>()
            .WithMessage("Initial stock must be greater than or equal to 0");        
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateMaterial_WithIllegalMaterialName_ThrowsException(string materialName)
    {
        var action = () => Material.Create("P12345", materialName, DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material name is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithNullMaterialType_ThrowsException()
    {
        var action = () => Material.Create("R12345", "Material name", null, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material type is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithNullAllergensByNature_ThrowsException()
    {
        var action = () => Material.Create("R12345", "Material name", DefaultMaterialType, "kg", "kilogram", 10, null, new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Allergens by nature information must be specified");
    }

    [Fact]
    public void CreateMaterial_WithNullAllergensByCrossContamination_ThrowsException()
    {
        var action = () => Material.Create("R12345", "Material name", DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), null);

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Allergens by cross-contamination information must be specified");
    }

    [Fact]
    public void CreateMaterial_WithEmptyAllergensByNatureAndCrossContaminationLists_CreatesMaterial()
    {
        var material = Material.Create("R12345", "Material name", DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        material.Id.Should().NotBeEmpty();
        material.CreatedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        material.Code.Value.Should().Be("R12345");
        material.Name.Should().Be("Material name");
        material.Type.Should().Be(DefaultMaterialType);
        material.Stock.UnitOfMeasure.Code.Should().Be("kg");
        material.Stock.UnitOfMeasure.Name.Should().Be("kilogram");
        material.Stock.CurrentAvailableStock.Should().Be(10);
        material.AllergensByNature.Allergens.Should().BeEquivalentTo(new List<Allergen>());
        material.AllergensByCrossContamination.Allergens.Should().BeEquivalentTo(new List<Allergen>());
    }    

    [Fact]
    public void CreateMaterial_WithFilledAllergensByNatureAndCrossContaminationLists_CreatesMaterial()
    {
        var allergensByNature = new[] { "Wheat", "Soy" }.ToList();
        var allergensByCrossContamination = new[] { "Soy", "Nuts" }.ToList();

        var material = Material.Create("R12345", "Material name", DefaultMaterialType, "kg", "kilogram", 10, allergensByNature, allergensByCrossContamination);

        material.Id.Should().NotBeEmpty();
        material.CreatedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        material.Code.Value.Should().Be("R12345");
        material.Name.Should().Be("Material name");
        material.Type.Should().Be(DefaultMaterialType);
        material.Stock.UnitOfMeasure.Code.Should().Be("kg");
        material.Stock.UnitOfMeasure.Name.Should().Be("kilogram");
        material.Stock.CurrentAvailableStock.Should().Be(10);
        material.AllergensByNature.Allergens.Should().BeEquivalentTo(new List<Allergen> { new Allergen("Wheat"), new Allergen("Soy") });
        material.AllergensByCrossContamination.Allergens.Should().BeEquivalentTo(new List<Allergen> { new Allergen("Soy"), new Allergen("Nuts") });
    } 
}