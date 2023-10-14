using MAM.Inventory.Infrastructure;
using MAM.Shared.GlobalEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Inventory.UseCases.DeleteInventory;

public class DeleteInventoryHandler : INotificationHandler<MaterialDeleted>
{
    private readonly InventoryDbContext _dbContext;

    public DeleteInventoryHandler(InventoryDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(MaterialDeleted notification, CancellationToken cancellationToken)
    {
        // todo: validation
        var stock = await _dbContext.Stocks
            .SingleAsync(x => x.MaterialId == notification.Id, cancellationToken);

        _dbContext.Stocks.Remove(stock);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}