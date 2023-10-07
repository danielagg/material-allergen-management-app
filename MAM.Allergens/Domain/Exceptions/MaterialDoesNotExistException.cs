using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class MaterialDoesNotExistException : DomainException
{
    public MaterialDoesNotExistException(string materialCode) : base($"A material with code '{materialCode}' does not exist.")
    {
    }
}