using MAM.Shared.Domain;
using MediatR;

namespace MAM.Allergens.UseCases.GetMaterialList;

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