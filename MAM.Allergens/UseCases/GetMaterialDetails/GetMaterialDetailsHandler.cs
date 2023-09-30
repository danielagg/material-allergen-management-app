using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.GetMaterialDetails;

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
        var entity = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleAsync(x => x.Id == request.MaterialId, cancellationToken);
            
        return new(entity);
    }
}