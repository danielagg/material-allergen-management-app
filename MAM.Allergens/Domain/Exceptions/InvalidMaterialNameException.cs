using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class InvalidMaterialNameException : DomainException
{
    public InvalidMaterialNameException(string message) : base(message)
    {
    }
}