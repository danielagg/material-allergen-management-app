using MediatR;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByCrossContamination.Add;

public class AddAllergenByCrossContaminationCommand : IRequest
{
    public string MaterialId { get; }
    public string NewAllergenByCrossContamination { get; }

    public AddAllergenByCrossContaminationCommand(string materialId, string newAllergenByCrossContamination)
    {
        MaterialId = materialId;
        NewAllergenByCrossContamination = newAllergenByCrossContamination;
    }
}