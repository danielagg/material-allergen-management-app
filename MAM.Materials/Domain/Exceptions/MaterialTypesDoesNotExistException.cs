using MAM.Shared.Domain;

namespace MAM.Materials.Domain.Exceptions;

public class MaterialTypesDoesNotExistException : DomainException
{
    public MaterialTypesDoesNotExistException(string message) : base(message)
    {
    }
}