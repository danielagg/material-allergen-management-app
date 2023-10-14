using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.DeleteMaterial;

public class DeleteMaterialHandler : IRequestHandler<DeleteMaterialCommand>
{
    private readonly AllergensDbContext _dbContext;

    public DeleteMaterialHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        _dbContext = dbContext;
    }
    
    public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Code.Value == request.MaterialCode, cancellationToken);

        if (material == null)
            throw new MaterialDoesNotExistException(request.MaterialCode);

        _dbContext.Materials.Remove(material);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}