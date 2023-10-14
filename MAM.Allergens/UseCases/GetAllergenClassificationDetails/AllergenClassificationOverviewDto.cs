namespace MAM.Allergens.UseCases.GetAllergenClassificationDetails;

public record AllergenClassificationDetailsDto(
    string MaterialId,
    List<string> AllergensByNature,
    List<string> AllergensByCrossContamination);
