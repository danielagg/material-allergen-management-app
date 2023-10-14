using MAM.Inventory.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Inventory.UseCases.InitializeInventory;

public class InitializeInventoryHandler : IRequestHandler<InitializeInventoryCommand>
{
    private readonly InventoryDbContext _dbContext;

    public InitializeInventoryHandler(InventoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(InitializeInventoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}