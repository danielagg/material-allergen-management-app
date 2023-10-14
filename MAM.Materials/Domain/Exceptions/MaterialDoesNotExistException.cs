using MAM.Shared.Domain;

namespace MAM.Materials.Domain.Exceptions;

public class MaterialDoesNotExistException : DomainException
{
    public MaterialDoesNotExistException() : base("The material does not exist.")
    {
    }
}