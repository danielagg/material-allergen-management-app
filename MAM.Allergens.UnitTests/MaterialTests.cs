using FluentAssertions;
using MAM.Allergens.Domain;
using MAM.Allergens.Domain.MaterialClassification;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.UnitTests;

public class MaterialTests
{
    private readonly MaterialType DefaultMaterialType = MaterialType.Create("material_type_id", "Material type name",
        new List<MaterialCategory> { MaterialCategory.RawMaterial }, DateTime.UtcNow);

    [Fact]
    public void CreateMaterial_WithNullMaterialId_ThrowsException()
    {
        var action = () =>  Material.Create(null, "Material name", DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material ID is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithEmptyStringMaterialId_ThrowsException()
    {
        var action = () =>  Material.Create(string.Empty, "Material name", DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material ID is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithNullMaterialName_ThrowsException()
    {
        var action = () =>  Material.Create("Material ID", null, DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material name is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithEmptyStringMaterialName_ThrowsException()
    {
        var action = () =>  Material.Create("Material ID", string.Empty, DefaultMaterialType, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material name is mandatory");
    }

    [Fact]
    public void CreateMaterial_WithNullMaterialType_ThrowsException()
    {
        var action = () =>  Material.Create("Material ID", "Material name", null, "kg", "kilogram", 10, new List<string>(), new List<string>());

        action
            .Should()
            .Throw<MaterialCannotBeCreatedWithMissingMandatoryParametersException>()
            .WithMessage("Material type is mandatory");
    }    
}