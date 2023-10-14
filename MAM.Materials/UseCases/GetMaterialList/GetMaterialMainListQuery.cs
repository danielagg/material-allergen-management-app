using MAM.Shared.Domain;
using MediatR;

namespace MAM.Materials.UseCases.GetMaterialList;

public class GetMaterialMainListQuery : IRequest<PaginatedResult<MaterialMainListDto>>
{
    public int Top { get; }
    public int Skip { get; }

    public GetMaterialMainListQuery(int top, int skip)
    {
        Top = top;
        Skip = skip;
    }
}