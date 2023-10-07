namespace MAM.Allergens.Domain.AllergenClassification;

public class AllergenByNature : IAllergenClassification<AllergenByNature>
{
    public IEnumerable<Allergen> Allergens { get; } = Enumerable.Empty<Allergen>();

    // for EF
    protected AllergenByNature()
    {
        
    }

    private AllergenByNature(IEnumerable<Allergen> initialAllergens)
    {
        Allergens = initialAllergens;
    }

    public static AllergenByNature Create(IEnumerable<Allergen> initialAllergens) => new(initialAllergens);

    public AllergenByNature ExtendWith(Allergen allergen)
    {
        var newItems = AllergenClassificationManager.TryAdd(Allergens, allergen);
        return new(newItems);
    }

    public AllergenByNature RemoveFrom(Allergen allergen)
    {
        var newItems = AllergenClassificationManager.TryRemove(Allergens, allergen);
        return new(newItems);
    }
}