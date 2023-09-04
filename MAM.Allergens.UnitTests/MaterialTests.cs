using FluentAssertions;
using MAM.Allergens.Domain;
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
    public void CreateMaterialCode_WithIncorrectlyFormattedMaterialId_ThrowsException(string materialCode, string expectedExceptionMessage)
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
    public void CreateMaterialCode_WithLegalValue_CreatesMaterialCode(string materialCode)
    {
        var result = MaterialCode.Create(materialCode);
        result.Value.Should().Be(materialCode);
    }

    [Fact]
    public void CreateMaterial_WithNullMaterialName_ThrowsException()
    {
        var action = () => Material.Create("Material ID", null, DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material name is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithEmptyStringMaterialName_ThrowsException()
    {
        var action = () => Material.Create("Material ID", string.Empty, DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

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