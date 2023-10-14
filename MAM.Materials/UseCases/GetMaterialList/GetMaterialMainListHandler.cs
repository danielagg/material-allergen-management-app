using MAM.Materials.Infrastructure;
using MAM.Shared.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Materials.UseCases.GetMaterialList;

public class GetMaterialMainListHandler : IRequestHandler<GetMaterialMainListQuery, PaginatedResult<MaterialMainListDto>>
{
    private readonly MaterialsDbContext _dbContext;

    public GetMaterialMainListHandler(MaterialsDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<MaterialMainListDto>> Handle(GetMaterialMainListQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Materials.CountAsync(cancellationToken);

        var result = await _dbContext.Materials
            .Include(x => x.Type)
            .OrderByDescending(x => x.CreatedOn)
            .Skip(request.Skip)
            .Take(request.Top)
            .ToListAsync(cancellationToken);

        var dtos = result.Select(x => new MaterialMainListDto(x));

        return PaginatedResult<MaterialMainListDto>.Create(dtos, totalCount, request.Skip);
    }
}