using MAM.Shared.Domain;

namespace MAM.Materials.Domain.Exceptions;

public class InvalidMaterialNameException : DomainException
{
    public InvalidMaterialNameException(string message) : base(message)
    {
    }
}