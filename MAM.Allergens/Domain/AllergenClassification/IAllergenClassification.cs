namespace MAM.Allergens.Domain.AllergenClassification;

public interface IAllergenClassification<out T>
{
    T Add(Allergen allergen);
    T Remove(Allergen allergen);
}