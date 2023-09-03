using MaterialAllergenManagementApp.Allergens;

namespace MaterialAllergenManagementApp.Allergens.DTOs;

public record CreateNewMaterialDto(
    string MaterialId,
    string MaterialName,
    string MaterialTypeId,
    string UnitOfMeasureCode,
    string UnitOfMeasureName,
    decimal InitialStock,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination);