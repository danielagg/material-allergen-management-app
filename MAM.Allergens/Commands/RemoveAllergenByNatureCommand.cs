using MediatR;
using MAM.Allergens.DTOs;

namespace MAM.Allergens.Commands;

public class RemoveAllergenByNatureCommand : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }
    public string AllergenByNatureToRemove { get; }

    public RemoveAllergenByNatureCommand(string materialId, string allergenByNatureToRemove)
    {
        MaterialId = materialId;
        AllergenByNatureToRemove = allergenByNatureToRemove;
    }
}