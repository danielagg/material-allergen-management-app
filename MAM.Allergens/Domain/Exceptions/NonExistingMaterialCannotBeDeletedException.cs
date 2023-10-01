using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class NonExistingMaterialCannotBeDeletedException : DomainException
{
    public NonExistingMaterialCannotBeDeletedException(string materialCode)
        : base($"Material '{materialCode}' cannot be deleted, since it does not exist.")
    {
    }
}