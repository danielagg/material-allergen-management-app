using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class InvalidMaterialCodeException : DomainException
{
    public InvalidMaterialCodeException(string message) : base(message)
    {
    }
}