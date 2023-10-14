using MediatR;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByCrossContamination.Remove;

public class RemoveAllergenByCrossContaminationCommand : IRequest
{
    public string MaterialId { get; }
    public string AllergenByCrossContaminationToRemove { get; }

    public RemoveAllergenByCrossContaminationCommand(string materialId, string allergenByCrossContaminationToRemove)
    {
        MaterialId = materialId;
        AllergenByCrossContaminationToRemove = allergenByCrossContaminationToRemove;
    }
}