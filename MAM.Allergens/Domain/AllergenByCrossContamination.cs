namespace MAM.Allergens.Domain;

public record AllergenByCrossContamination(List<IndividualAllergen> Allergens)
{
    public void Add(IndividualAllergen newAllergen) => Allergens.Add(newAllergen);
    public void Remove(IndividualAllergen existingAllergen) => Allergens.Remove(existingAllergen);
}
