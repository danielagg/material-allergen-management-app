using MediatR;
using MAM.Allergens.DTOs;

namespace MAM.Allergens.Commands;

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