using FluentAssertions;
using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.Exceptions;

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
        var action = () => Material.Create("Material ID", "Material name", null, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material type is mandatory");
    }     
}