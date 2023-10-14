using MAM.Materials.Domain.Exceptions;
using MAM.Materials.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Materials.UseCases.GetMaterialDetails;

public class GetMaterialDetailsHandler : IRequestHandler<GetMaterialDetailsQuery, MaterialDetailsDto>
{
    private readonly MaterialsDbContext _dbContext;

    public GetMaterialDetailsHandler(MaterialsDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }

    public async Task<MaterialDetailsDto> Handle(GetMaterialDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Id == request.MaterialId, cancellationToken);

        if (entity is null)
            throw new MaterialDoesNotExistException();
        
        return new(entity);
    }
}