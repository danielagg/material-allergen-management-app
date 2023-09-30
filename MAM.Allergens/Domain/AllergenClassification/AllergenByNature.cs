namespace MAM.Allergens.Domain.AllergenClassification;

public class AllergenByNature
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

    public AllergenByNature Add(Allergen allergen)
    {
        // todo: validation
        var newItems = Allergens.Concat(new[] { allergen });
        return new AllergenByNature(newItems);
    }

    public AllergenByNature Remove(Allergen allergen)
    {
        var newItems = Allergens.Where(existingItem => !existingItem.Equals(allergen));
        return new AllergenByNature(newItems);
    }
}