using MediatR;
using MAM.Allergens.DTOs;

namespace MAM.Allergens.Commands;

public class AddAllergenByNatureCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }
    public string NewAllergenByNature { get; }

    public AddAllergenByNatureCommand(string materialId, string newAllergenByNature)
    {
        MaterialId = materialId;
        NewAllergenByNature = newAllergenByNature;
    }
}