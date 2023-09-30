using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class CannotAddDuplicateAllergensException : DomainException
{
    public CannotAddDuplicateAllergensException(string message) : base(message)
    {
    }
}