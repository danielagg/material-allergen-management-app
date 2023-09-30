using FluentAssertions;
using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.UnitTests;

public class MaterialNameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateMaterial_WithIllegalShortMaterialName_ThrowsException(string shortMaterialName)
    {
        var action = () => MaterialName.Create(shortMaterialName, "Full Material Name");

        action
            .Should()
            .Throw<InvalidMaterialNameException>()
            .WithMessage("The short name of the material cannot be empty");
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateMaterial_WithIllegalFullMaterialName_ThrowsException(string fullMaterialName)
    {
        var action = () => MaterialName.Create("Short Material Name", fullMaterialName);

        action
            .Should()
            .Throw<InvalidMaterialNameException>()
            .WithMessage("The full name of the material cannot be empty");
    }
}