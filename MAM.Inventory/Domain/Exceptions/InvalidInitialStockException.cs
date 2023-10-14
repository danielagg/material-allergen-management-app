using MAM.Shared.Domain;

namespace MAM.Inventory.Domain.Exceptions;

public class InvalidInitialStockException : DomainException
{
    public InvalidInitialStockException() : base("Initial stock must be greater than or equal to 0.")
    {
    }
}