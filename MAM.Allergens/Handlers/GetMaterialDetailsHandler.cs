using MAM.Allergens.DTOs;
using MAM.Allergens.Queries;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Handlers;

public class GetMaterialDetailsHandler : IRequestHandler<GetMaterialDetailsQuery, MaterialAllergenDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public GetMaterialDetailsHandler(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MaterialAllergenDetailsDto> Handle(GetMaterialDetailsQuery request, CancellationToken cancellationToken)
    {
        // todo: proper error handling
        var entity = await _dbContext.Materials.SingleAsync(x => x.Id == request.Id);
        return new(entity);
    }
}