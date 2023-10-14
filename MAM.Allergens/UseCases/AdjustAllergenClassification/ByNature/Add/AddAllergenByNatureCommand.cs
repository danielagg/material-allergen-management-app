using MediatR;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByNature.Add;

public class AddAllergenByNatureCommand : IRequest
{
    public string MaterialId { get; }
    public string NewAllergenByNature { get; }

    public AddAllergenByNatureCommand(string materialId, string newAllergenByNature)
    {
        MaterialId = materialId;
        NewAllergenByNature = newAllergenByNature;
    }
}