using MAM.Allergens.Domain.Exceptions;
using MAM.Shared.Domain;

namespace MAM.Allergens.Domain;

public class AllergenClassification : Entity
{
    public string MaterialId { get; private set; }

    public AllergenByNature ByNatureAllergens { get; private set; }
    public AllergenByCrossContamination CrossContaminatingAllergens { get; private set; }
    
    // for EF (requires a param-less ctor)
    protected AllergenClassification()
    {
        
    }

    public AllergenClassification(
        string materialId,
        AllergenByNature byNatureAllergens,
        AllergenByCrossContamination crossContaminatingAllergens) : base()
    {
        MaterialId = materialId;
        ByNatureAllergens = byNatureAllergens;
        CrossContaminatingAllergens = crossContaminatingAllergens;
    }

    public bool HasAllergensByNature() => ByNatureAllergens.Allergens.Any();
    public bool HasAllergensByCrossContamination() => CrossContaminatingAllergens.Allergens.Any();
    
    // todo: these can be done better:
    public void AddNewAllergenByNature(IndividualAllergen allergen)
    {
        AssertNoDuplication(ByNatureAllergens.Allergens, allergen);
        ByNatureAllergens = ByNatureAllergens.Append(allergen);
    }
    
    public void RemoveExistingAllergenByNature(IndividualAllergen allergen)
    {
        AssertAllergenExists(ByNatureAllergens.Allergens, allergen);
        ByNatureAllergens = ByNatureAllergens.Remove(allergen);
    }
    
    public void AddNewAllergenByCrossContamination(IndividualAllergen allergen)
    {
        AssertNoDuplication(CrossContaminatingAllergens.Allergens, allergen);
        CrossContaminatingAllergens = CrossContaminatingAllergens.Append(allergen);
    }
    
    public void RemoveExistingAllergenByCrossContamination(IndividualAllergen allergen)
    {
        AssertAllergenExists(CrossContaminatingAllergens.Allergens, allergen);
        CrossContaminatingAllergens = CrossContaminatingAllergens.Remove(allergen);
    }
    
    private void AssertNoDuplication(List<IndividualAllergen> allergens, IndividualAllergen newAllergen)
    {
        if (allergens.Contains(newAllergen))
        {
            throw new CannotAddDuplicateAllergensException(
                $"Cannot add duplicate allergens: the allergen '{newAllergen.Name}' cannot appear multiple times.");
        }
    }

    private void AssertAllergenExists(List<IndividualAllergen> allergens, IndividualAllergen allergenToRemove)
    {
        if (!allergens.Contains(allergenToRemove))
        {
            throw new CannotRemoveNotPresentAllergensException(
                $"Cannot remove not present allergen: the allergen '{allergenToRemove.Name}' cannot be removed, as it's not present in the current set of allergens.");            
        }
    }
}