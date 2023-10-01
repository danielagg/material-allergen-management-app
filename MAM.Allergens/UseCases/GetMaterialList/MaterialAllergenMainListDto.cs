using MAM.Allergens.Domain;
using MAM.Shared.Domain;

namespace MAM.Allergens.UseCases.GetMaterialList;

public record MaterialAllergenMainListDto(
    string MaterialCode,
    DateTime CreatedOn,
    string ShortName,
    string FullName,
    bool HasAllergensByNature,
    bool HasAllergensByCrossContamination,
    string MaterialType)
{
    public MaterialAllergenMainListDto(Material material) : this(
        material.Code.Value,
        material.CreatedOn,
        material.Name.ShortName,
        material.Name.FullName,
        material.AllergensByNature.Allergens.Any(),
        material.AllergensByCrossContamination.Allergens.Any(),
        material.Type.Name) { }
}