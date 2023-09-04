using MAM.Shared.Domain;

namespace MAM.Allergens.Domain.Exceptions;

public class MaterialCannotBeCreatedWithMissingMandatoryParametersException : DomainException
{
    public MaterialCannotBeCreatedWithMissingMandatoryParametersException(string message) : base(message)
    {
    }
}