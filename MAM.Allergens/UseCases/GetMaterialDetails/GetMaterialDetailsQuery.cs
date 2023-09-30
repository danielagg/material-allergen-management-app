using MediatR;

namespace MAM.Allergens.UseCases.GetMaterialDetails;

public class GetMaterialDetailsQuery : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }

    public GetMaterialDetailsQuery(string materialId)
    {
        MaterialId = materialId;
    }
}