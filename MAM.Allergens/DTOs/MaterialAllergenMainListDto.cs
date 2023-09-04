using MAM.Allergens.Domain;
using MAM.Shared.Domain;
using System.Linq;

namespace MAM.Allergens.DTOs;

public record MaterialAllergenMainListDto(
    string Id,
    DateTime CreatedOn,
    IdNameModel<string> Material,
    bool HasAllergensByNature,
    bool HasAllergensByCrossContamination,
    string MaterialType)
{
    public MaterialAllergenMainListDto(Material material) : this(
        material.Id,
        material.CreatedOn,
        new IdNameModel<string>(material.Code.Value, material.Name),
        material.AllergensByNature.Allergens.Any(),
        material.AllergensByCrossContamination.Allergens.Any(),
        material.Type.Name) { }
}