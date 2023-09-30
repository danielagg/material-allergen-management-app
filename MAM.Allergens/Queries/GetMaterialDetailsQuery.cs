using MAM.Allergens.DTOs;
using MediatR;

namespace MAM.Allergens.Queries;

public class GetMaterialDetailsQuery : IRequest<MaterialAllergenDetailsDto>
{
    public string MaterialId { get; }

    public GetMaterialDetailsQuery(string materialId)
    {
        MaterialId = materialId;
    }
}