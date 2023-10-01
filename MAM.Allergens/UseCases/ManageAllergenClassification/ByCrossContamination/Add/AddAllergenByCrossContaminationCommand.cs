using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Add;

public class AddAllergenByCrossContaminationCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialCode { get; }
    public string NewAllergenByCrossContamination { get; }

    public AddAllergenByCrossContaminationCommand(string materialCode, string newAllergenByCrossContamination)
    {
        MaterialCode = materialCode;
        NewAllergenByCrossContamination = newAllergenByCrossContamination;
    }
}