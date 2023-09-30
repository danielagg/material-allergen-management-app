namespace MAM.Allergens.Domain.AllergenClassification;

public class AllergenByCrossContamination
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
        // todo: validation
        var newItems = Allergens.Concat(new[] { allergen });
        return new AllergenByCrossContamination(newItems);
    }

    public AllergenByCrossContamination Remove(Allergen allergen)
    {
        // todo: validation
        var newItems = Allergens.Where(existingItem => !existingItem.Equals(allergen));
        return new AllergenByCrossContamination(newItems);
    }
}