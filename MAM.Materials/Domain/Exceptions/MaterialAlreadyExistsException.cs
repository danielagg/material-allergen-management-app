using MAM.Shared.Domain;

namespace MAM.Materials.Domain.Exceptions;

public class MaterialAlreadyExistsException : DomainException
{
    public MaterialAlreadyExistsException(string materialCode) : base(
        $"A material with the code '${materialCode}' already exists, therefore it cannot be created again.")
    {
    }
}