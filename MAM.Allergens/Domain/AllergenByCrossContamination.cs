namespace MAM.Allergens.Domain;

public record AllergenByCrossContamination(List<IndividualAllergen> Allergens)
{
    public AllergenByCrossContamination Append(IndividualAllergen newAllergen) =>
        new(Allergens.Concat(new[] { newAllergen }).ToList());

    public AllergenByCrossContamination Remove(IndividualAllergen existingAllergen) =>
        new(Allergens.Except(new[] { existingAllergen }).ToList());
}
