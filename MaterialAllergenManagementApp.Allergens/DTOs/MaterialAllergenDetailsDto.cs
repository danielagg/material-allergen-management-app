using MaterialAllergenManagementApp.Allergens;
using MaterialAllergenManagementApp.Shared.Domain;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record MaterialAllergenDetailsDto(
    string Id,
    DateTime CreatedOn,
    IdNameModel<string> Material,
    bool AllergenByNature,
    bool AllergenByCrossContamination)
{
    public MaterialAllergenDetailsDto(Material material) : this(
        material.Id,
        material.CreatedOn,
        material.Identification,
        material.AllergenByNature,
        material.AllergenByCrossContamination) { }
}