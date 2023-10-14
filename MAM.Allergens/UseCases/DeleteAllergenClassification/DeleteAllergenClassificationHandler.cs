using MAM.Allergens.Infrastructure;
using MAM.Shared.GlobalEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.DeleteAllergenClassification;

public class DeleteAllergenClassificationHandler : INotificationHandler<MaterialDeleted>
{
    private readonly AllergensDbContext _dbContext;

    public DeleteAllergenClassificationHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(MaterialDeleted notification, CancellationToken cancellationToken)
    {
        // todo: validation
        var allergenClassification = await _dbContext.AllergenClassifications
            .SingleAsync(x => x.MaterialId == notification.Id, cancellationToken);

        _dbContext.AllergenClassifications.Remove(allergenClassification);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}