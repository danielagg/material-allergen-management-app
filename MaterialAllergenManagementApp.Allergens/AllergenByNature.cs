namespace MaterialAllergenManagementApp.Allergens;

public class AllergenByNature
{
    public List<Allergen> Allergens { get; private set; }

    // for EF
    protected AllergenByNature()
    {
        
    }

    private AllergenByNature(List<Allergen> initialAllergens)
    {
        Allergens = initialAllergens;
    }

    public static AllergenByNature Create(List<Allergen> initialAllergens) => new(initialAllergens);

    public void Add(Allergen allergen)
    {
        // todo: validation
        Allergens.Add(allergen);
    }

    public void Remove(Allergen allergen)
    {
        // todo: validation
        Allergens.Remove(allergen);
    }
}