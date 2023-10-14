using MAM.Shared.Domain;

namespace MAM.Materials.Domain.Exceptions;

public class InvalidMaterialCodeException : DomainException
{
    public InvalidMaterialCodeException(string message) : base(message)
    {
    }
}