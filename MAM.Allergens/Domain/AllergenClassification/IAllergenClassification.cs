namespace MAM.Allergens.Domain.AllergenClassification;

public interface IAllergenClassification<out T>
{
    T ExtendWith(Allergen allergen);
    T RemoveFrom(Allergen allergen);
}