using MediatR;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByNature.Remove;

public class RemoveAllergenByNatureCommand : IRequest
{
    public string MaterialId { get; }
    public string AllergenByNatureToRemove { get; }

    public RemoveAllergenByNatureCommand(string materialId, string allergenByNatureToRemove)
    {
        MaterialId = materialId;
        AllergenByNatureToRemove = allergenByNatureToRemove;
    }
}