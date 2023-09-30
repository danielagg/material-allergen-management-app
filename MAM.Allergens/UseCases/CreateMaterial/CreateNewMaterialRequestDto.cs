namespace MAM.Allergens.UseCases.CreateMaterial;

public record CreateNewMaterialRequestDto(
    string MaterialCode,
    string ShortMaterialName,
    string FullMaterialName,
    string MaterialTypeId,
    string UnitOfMeasureCode,
    string UnitOfMeasureName,
    decimal InitialStock,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination);