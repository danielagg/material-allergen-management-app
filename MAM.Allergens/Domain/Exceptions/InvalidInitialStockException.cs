using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class InvalidInitialStockException : DomainException
{
    public InvalidInitialStockException() : base("Initial stock must be greater than or equal to 0")
    {
    }
}