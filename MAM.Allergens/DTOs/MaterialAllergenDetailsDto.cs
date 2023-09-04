using MAM.Allergens.Domain;
using MAM.Shared.Domain;

namespace MAM.Allergens.DTOs;

public record MaterialAllergenDetailsDto(
    string Id,
    DateTime CreatedOn,
    IdNameModel<string> Material,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination)
{
    public MaterialAllergenDetailsDto(Material material) : this(
        material.Id,
        material.CreatedOn,
        new IdNameModel<string>(material.Code.Value, material.Name),
        material.AllergensByNature.Allergens.Select(a => a.Name).ToList(),
        material.AllergensByCrossContamination.Allergens.Select(a => a.Name).ToList()) { }
}