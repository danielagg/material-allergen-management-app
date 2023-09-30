using MediatR;
using MAM.Allergens.DTOs;

namespace MAM.Allergens.Commands;

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