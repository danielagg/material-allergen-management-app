namespace MAM.Allergens.Domain.AllergenClassification;

public record AllergenByNature(IEnumerable<Allergen> Allergens)
{
    public AllergenByNature ExtendWith(Allergen allergen) =>
        new(AllergenClassificationManager.TryAdd(Allergens, allergen));

    public AllergenByNature RemoveFrom(Allergen allergen) =>
        new(AllergenClassificationManager.TryRemove(Allergens, allergen));
}