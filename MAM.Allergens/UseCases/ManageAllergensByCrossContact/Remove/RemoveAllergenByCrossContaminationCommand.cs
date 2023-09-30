using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergensByCrossContact.Remove;

public class RemoveAllergenByCrossContaminationCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }
    public string AllergenByCrossContaminationToRemove { get; }

    public RemoveAllergenByCrossContaminationCommand(string materialId, string allergenByCrossContaminationToRemove)
    {
        MaterialId = materialId;
        AllergenByCrossContaminationToRemove = allergenByCrossContaminationToRemove;
    }
}