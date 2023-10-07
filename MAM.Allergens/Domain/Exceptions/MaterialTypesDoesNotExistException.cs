using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class MaterialTypesDoesNotExistException : DomainException
{
    public MaterialTypesDoesNotExistException(string message) : base(message)
    {
    }
}