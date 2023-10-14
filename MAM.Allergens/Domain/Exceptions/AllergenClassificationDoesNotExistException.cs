using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class AllergenClassificationDoesNotExistException : DomainException
{
    public AllergenClassificationDoesNotExistException() : base("No allergen classification exists for the material(s).")
    {
    }
}