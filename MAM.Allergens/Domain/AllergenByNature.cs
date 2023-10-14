namespace MAM.Allergens.Domain;

public record AllergenByNature(List<IndividualAllergen> Allergens)
{
    public AllergenByNature Append(IndividualAllergen newAllergen) =>
        new(Allergens.Concat(new[] { newAllergen }).ToList());

    public AllergenByNature Remove(IndividualAllergen existingAllergen) =>
        new(Allergens.Except(new[] { existingAllergen }).ToList());
}
