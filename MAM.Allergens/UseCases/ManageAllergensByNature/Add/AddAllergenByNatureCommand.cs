using MAM.Allergens.UseCases.GetMaterialDetails;
using MediatR;

namespace MAM.Allergens.UseCases.ManageAllergensByNature.Add;

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