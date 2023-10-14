using MAM.Allergens.Infrastructure;
using MAM.Shared.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.GetMaterialList;

public class GetMaterialMainListHandler : IRequestHandler<GetMaterialMainListQuery, PaginatedResult<MaterialAllergenMainListDto>>
{
    private readonly AllergensDbContext _dbContext;

    public GetMaterialMainListHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<MaterialAllergenMainListDto>> Handle(GetMaterialMainListQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Materials.CountAsync(cancellationToken);

        var result = await _dbContext.Materials
            .Include(x => x.Type)
            .OrderByDescending(x => x.CreatedOn)
            .Skip(request.Skip)
            .Take(request.Top)
            .ToListAsync(cancellationToken);

        var dtos = result.Select(x => new MaterialAllergenMainListDto(x));

        return PaginatedResult<MaterialAllergenMainListDto>.Create(dtos, totalCount, request.Skip);
    }
}