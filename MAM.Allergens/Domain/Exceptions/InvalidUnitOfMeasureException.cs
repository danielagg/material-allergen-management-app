using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class InvalidUnitOfMeasureException : DomainException
{
    public InvalidUnitOfMeasureException(string message) : base(message)
    {
    }
}