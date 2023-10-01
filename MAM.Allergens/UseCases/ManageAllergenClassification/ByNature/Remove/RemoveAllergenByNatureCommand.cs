using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Remove;

public class RemoveAllergenByNatureCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialCode { get; }
    public string AllergenByNatureToRemove { get; }

    public RemoveAllergenByNatureCommand(string materialCode, string allergenByNatureToRemove)
    {
        MaterialCode = materialCode;
        AllergenByNatureToRemove = allergenByNatureToRemove;
    }
}