using MAM.Materials.Domain.MaterialClassification;
using Xunit;
using FluentAssertions;
using MAM.Materials.Domain;

namespace MAM.Materials.UnitTests;

public class MaterialTests
{
    private readonly MaterialCode _defaultLegalMaterialCode = MaterialCode.Create("R12345");
    private readonly MaterialName _defaultLegalMaterialName = MaterialName.Create("Short Material Name", "Full Material Name");
    
    private readonly MaterialType _defaultLegalMaterialType = MaterialType.Create("material_type_id", "Material type name",
        new List<MaterialCategory> { MaterialCategory.RawMaterial }, DateTime.UtcNow);
    
    [Fact]
    public void CreateMaterial_WithLegalParameters_CreatesMaterial()
    {
        var material = Material.Create(
            _defaultLegalMaterialCode,
            _defaultLegalMaterialName,
            _defaultLegalMaterialType);

        material.IfSucc(m =>
        {
            m.Id.Should().NotBeEmpty();
            m.CreatedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            m.Code.Value.Should().Be(_defaultLegalMaterialCode.Value);
            m.Name.ShortName.Should().Be(_defaultLegalMaterialName.ShortName);
            m.Name.FullName.Should().Be(_defaultLegalMaterialName.FullName);
            m.Type.Should().Be(_defaultLegalMaterialType);
        });
    }    
}