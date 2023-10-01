using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Remove;

public class RemoveAllergenByCrossContaminationCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialCode { get; }
    public string AllergenByCrossContaminationToRemove { get; }

    public RemoveAllergenByCrossContaminationCommand(string materialCode, string allergenByCrossContaminationToRemove)
    {
        MaterialCode = materialCode;
        AllergenByCrossContaminationToRemove = allergenByCrossContaminationToRemove;
    }
}