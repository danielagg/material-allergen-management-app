namespace MaterialAllergenManagementApp.Allergens;

public class AllergenByCrossContamination
{
    public List<Allergen> Allergens { get; private set; }

    // for EF
    protected AllergenByCrossContamination()
    {
        
    }

    private AllergenByCrossContamination(List<Allergen> initialAllergens)
    {
        Allergens = initialAllergens;
    }

    public static AllergenByCrossContamination Create(List<Allergen> initialAllergens) => new(initialAllergens);

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