using MAM.Materials.Domain;

namespace MAM.Materials.UseCases.GetMaterialDetails;

public record MaterialDetailsDto(
    string Id,
    string MaterialCode,
    string ShortMaterialName,
    string FullMaterialName,
    DateTime CreatedOn)
{
    public MaterialDetailsDto(Material material) : this(
        material.Id,
        material.Code.Value,
        material.Name.ShortName,
        material.Name.FullName,
        material.CreatedOn) { }
}