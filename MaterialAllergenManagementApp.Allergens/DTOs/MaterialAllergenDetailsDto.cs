using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

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
        material.Identification,
        material.AllergensByNature.Allergens.Select(a => a.Name).ToList(),
        material.AllergensByCrossContamination.Allergens.Select(a => a.Name).ToList()) { }
}