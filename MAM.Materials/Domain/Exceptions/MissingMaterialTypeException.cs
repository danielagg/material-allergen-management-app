using MAM.Shared.Domain;

namespace MAM.Materials.Domain.Exceptions;

public class MissingMaterialTypeException : DomainException
{
    public MissingMaterialTypeException() : base("Materials cannot be created without a MaterialType specified.")
    {
    }
}