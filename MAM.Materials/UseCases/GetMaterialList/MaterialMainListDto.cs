using MAM.Materials.Domain;

namespace MAM.Materials.UseCases.GetMaterialList;

public record MaterialMainListDto(
    string Id,
    string MaterialCode,
    DateTime CreatedOn,
    string ShortName,
    string FullName,
    string MaterialType)
{
    public MaterialMainListDto(Material material) : this(
        material.Id,
        material.Code.Value,
        material.CreatedOn,
        material.Name.ShortName,
        material.Name.FullName,
        material.Type.Name) { }
}