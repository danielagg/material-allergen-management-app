using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class MissingUnitOfMeasureException : DomainException
{
    public MissingUnitOfMeasureException() : base("Initial stock must have a unit of measure")
    {
    }
}