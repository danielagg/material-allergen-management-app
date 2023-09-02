using MaterialAllergenManagementApp.Allergens;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record CreateNewMaterialDto(
    string MaterialId,
    string MaterialName,
    bool AllergenByNature,
    bool AllergenByCrossContamination);