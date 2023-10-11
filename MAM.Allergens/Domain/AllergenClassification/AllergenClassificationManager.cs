using MAM.Allergens.Domain.Exceptions;

namespace MAM.Allergens.Domain.AllergenClassification;

public static class AllergenClassificationManager
{
    public static List<Allergen> TryAdd(List<Allergen> allergens, Allergen newAllergen)
    {
        if (allergens.Contains(newAllergen))
        {
            throw new CannotAddDuplicateAllergensException(
                $"Cannot add duplicate allergens: the allergen '{newAllergen.Name}' cannot appear multiple times.");
        }
            
        return allergens.Concat(new[] { newAllergen }).ToList();
    }

    public static List<Allergen> TryRemove(List<Allergen> allergens, Allergen allergenToRemove)
    {
        if (!allergens.Contains(allergenToRemove))
        {
            throw new CannotRemoveNotPresentAllergensException(
                $"Cannot remove not present allergen: the allergen '{allergenToRemove.Name}' cannot be removed, as it's not present in the current set of allergens.");            
        }

        return allergens.Where(existingItem => !existingItem.Equals(allergenToRemove)).ToList();
    }
}