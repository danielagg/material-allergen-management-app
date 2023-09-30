using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Add;

public class AddAllergenByCrossContaminationCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }
    public string NewAllergenByCrossContamination { get; }

    public AddAllergenByCrossContaminationCommand(string materialId, string newAllergenByCrossContamination)
    {
        MaterialId = materialId;
        NewAllergenByCrossContamination = newAllergenByCrossContamination;
    }
}