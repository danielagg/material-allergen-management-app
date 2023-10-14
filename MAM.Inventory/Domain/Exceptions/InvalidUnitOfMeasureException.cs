using MAM.Shared.Domain;

namespace MAM.Inventory.Domain.Exceptions;

public class InvalidUnitOfMeasureException : DomainException
{
    public InvalidUnitOfMeasureException(string message) : base(message)
    {
    }
}