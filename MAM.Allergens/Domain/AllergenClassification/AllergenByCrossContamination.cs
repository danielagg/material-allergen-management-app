namespace MAM.Allergens.Domain.AllergenClassification;

public record AllergenByCrossContamination(IEnumerable<Allergen> Allergens)
{
    public AllergenByCrossContamination ExtendWith(Allergen allergen) =>
        new(AllergenClassificationManager.TryAdd(Allergens, allergen));

    public AllergenByCrossContamination RemoveFrom(Allergen allergen) =>
        new(AllergenClassificationManager.TryRemove(Allergens, allergen));
}