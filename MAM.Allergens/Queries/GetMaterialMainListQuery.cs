using MAM.Allergens.Domain;
using MAM.Shared.Domain;
using MAM.Allergens.DTOs;
using MediatR;

namespace MAM.Allergens.Queries;

public class GetMaterialMainListQuery : IRequest<PaginatedResult<MaterialAllergenMainListDto>>
{
    public int Top { get; }
    public int Skip { get; }

    public GetMaterialMainListQuery(int top, int skip)
    {
        Top = top;
        Skip = skip;
    }
}