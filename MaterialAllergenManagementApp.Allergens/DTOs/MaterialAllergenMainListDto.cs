using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;
using System.Linq;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record MaterialAllergenMainListDto(
    string Id,
    DateTime CreatedOn,
    IdNameModel<string> Material,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination)
{
    public MaterialAllergenMainListDto(Material material) : this(
        material.Id,
        material.CreatedOn,
        material.Identification,
        material.AllergensByNature.Allergens.Select(a => a.Name).ToList(),
        material.AllergensByCrossContamination.Allergens.Select(a => a.Name).ToList()) { }
}