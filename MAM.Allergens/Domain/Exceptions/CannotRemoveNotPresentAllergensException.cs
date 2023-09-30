using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class CannotRemoveNotPresentAllergensException : DomainException
{
    public CannotRemoveNotPresentAllergensException(string message) : base(message)
    {
    }
}