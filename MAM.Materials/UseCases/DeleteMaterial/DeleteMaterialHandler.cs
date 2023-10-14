using MAM.Materials.Domain.Exceptions;
using MAM.Materials.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Materials.UseCases.DeleteMaterial;

public class DeleteMaterialHandler : IRequestHandler<DeleteMaterialCommand>
{
    private readonly MaterialsDbContext _dbContext;

    public DeleteMaterialHandler(MaterialsDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        _dbContext = dbContext;
    }
    
    public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Id == request.MaterialId, cancellationToken);

        if (material == null)
            throw new MaterialDoesNotExistException();

        _dbContext.Materials.Remove(material);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}