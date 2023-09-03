using MAM.Allergens.DTOs;
using MediatR;

namespace MAM.Allergens.Queries;

public class GetMaterialDetailsQuery : IRequest<MaterialAllergenDetailsDto>
{
    public string Id { get; }

    public GetMaterialDetailsQuery(string id)
    {
        Id = id;
    }
}