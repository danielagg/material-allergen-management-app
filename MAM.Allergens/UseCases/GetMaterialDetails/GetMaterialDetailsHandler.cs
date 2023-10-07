using MAM.Allergens.Domain.Exceptions;
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
        var entity = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Code.Value == request.MaterialCode, cancellationToken);

        if (entity is null)
            throw new MaterialDoesNotExistException(request.MaterialCode);
        
        return new(entity);
    }
}