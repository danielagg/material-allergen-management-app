using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergensByNature.Remove;

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