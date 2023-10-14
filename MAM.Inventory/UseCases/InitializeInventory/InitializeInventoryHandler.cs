using MAM.Inventory.Domain;
using MAM.Inventory.Infrastructure;
using MAM.Shared.GlobalEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Inventory.UseCases.InitializeInventory;

public class InitializeInventoryHandler : INotificationHandler<NewMaterialCreated>
{
    private readonly InventoryDbContext _dbContext;

    public InitializeInventoryHandler(InventoryDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(NewMaterialCreated notification, CancellationToken cancellationToken)
    {
        var unitOfMeasure = UnitOfMeasure.Create(notification.UnitOfMeasureCode, notification.UnitOfMeasureName);
        var stock = Stock.CreateInitialStock(unitOfMeasure, notification.InitialStock);

        await _dbContext.Stocks.AddAsync(stock, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}