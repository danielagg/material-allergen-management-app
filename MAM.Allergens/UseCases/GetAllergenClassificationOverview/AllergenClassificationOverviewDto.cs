namespace MAM.Allergens.UseCases.GetAllergenClassificationOverview;

public record AllergenClassificationOverviewDto(
    string MaterialId,
    bool HasAllergensByNature,
    bool HasAllergensByCrossContamination);
