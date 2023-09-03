using MAM.Allergens.DTOs;
using MAM.Allergens.Queries;
using MAM.Allergens.Infrastructure;
using MAM.Shared.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Handlers;

public class GetMaterialMainListHandler : IRequestHandler<GetMaterialMainListQuery, PaginatedResult<MaterialAllergenMainListDto>>
{
    private readonly AllergensDbContext _dbContext;

    public GetMaterialMainListHandler(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<MaterialAllergenMainListDto>> Handle(GetMaterialMainListQuery request, CancellationToken cancellationToken)
    {
        var totalCount = await _dbContext.Materials.CountAsync();

        var result = await _dbContext.Materials
            .Include(x => x.Type)
            .OrderByDescending(x => x.CreatedOn)
            .Skip(request.Skip)
            .Take(request.Top)
            .ToListAsync();

        var dtos = result.Select(x => new MaterialAllergenMainListDto(x));

        return PaginatedResult<MaterialAllergenMainListDto>.Create(dtos, totalCount, request.Skip);
    }
}