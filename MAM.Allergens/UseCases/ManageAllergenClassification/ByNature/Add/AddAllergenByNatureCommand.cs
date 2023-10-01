using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Add;

public class AddAllergenByNatureCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialCode { get; }
    public string NewAllergenByNature { get; }

    public AddAllergenByNatureCommand(string materialCode, string newAllergenByNature)
    {
        MaterialCode = materialCode;
        NewAllergenByNature = newAllergenByNature;
    }
}