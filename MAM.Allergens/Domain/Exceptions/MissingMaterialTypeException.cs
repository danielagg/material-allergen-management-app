using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class MissingMaterialTypeException : DomainException
{
    public MissingMaterialTypeException() : base("Materials cannot be created without a MaterialType specified.")
    {
    }
}