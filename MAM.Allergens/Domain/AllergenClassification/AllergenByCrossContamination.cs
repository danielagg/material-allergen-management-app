namespace MAM.Allergens.Domain.AllergenClassification;

public class AllergenByCrossContamination : IAllergenClassification<AllergenByCrossContamination>
{
    public IEnumerable<Allergen> Allergens { get; } = Enumerable.Empty<Allergen>();

    // for EF
    protected AllergenByCrossContamination()
    {
        
    }

    private AllergenByCrossContamination(IEnumerable<Allergen> initialAllergens)
    {
        Allergens = initialAllergens;
    }

    public static AllergenByCrossContamination Create(IEnumerable<Allergen> initialAllergens) => new(initialAllergens);

    public AllergenByCrossContamination Add(Allergen allergen)
    {
        var newItems = AllergenClassificationManager.TryAdd(Allergens, allergen);
        return new(newItems);
    }

    public AllergenByCrossContamination Remove(Allergen allergen)
    {
        var newItems = AllergenClassificationManager.TryRemove(Allergens, allergen);
        return new(newItems);
    }
}