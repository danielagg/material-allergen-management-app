using MAM.Materials.Domain.Exceptions;
using MAM.Materials.Infrastructure;
using MAM.Shared.GlobalEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Materials.UseCases.DeleteMaterial;

public class DeleteMaterialHandler : IRequestHandler<DeleteMaterialCommand>
{
    private readonly MaterialsDbContext _dbContext;
    private readonly IMediator _mediator;

    public DeleteMaterialHandler(MaterialsDbContext dbContext, IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(mediator);

        _dbContext = dbContext;
        _mediator = mediator;
    }
    
    public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleOrDefaultAsync(x => x.Id == request.MaterialId, cancellationToken);

        if (material is null)
            throw new MaterialDoesNotExistException();

        _dbContext.Materials.Remove(material);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new MaterialDeleted(request.MaterialId), cancellationToken);
    }
}