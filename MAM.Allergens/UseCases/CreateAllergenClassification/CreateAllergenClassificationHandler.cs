using MAM.Allergens.Domain;
using MAM.Allergens.Infrastructure;
using MAM.Shared.GlobalEvents;
using MediatR;

namespace MAM.Allergens.UseCases.CreateAllergenClassification;

public class CreateAllergenClassificationHandler : INotificationHandler<NewMaterialCreated>
{
    private readonly AllergensDbContext _dbContext;

    public CreateAllergenClassificationHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(NewMaterialCreated notification, CancellationToken cancellationToken)
    {
        // todo: validation
        var allergensByNature = new AllergenByNature(
            notification.AllergensByNature.Select(a => new IndividualAllergen(a)).ToList());
        
        var allergensByCrossContamination = new AllergenByCrossContamination(
            notification.AllergensByCrossContamination.Select(a => new IndividualAllergen(a)).ToList());
        
        var allergenClassification = new AllergenClassification(
            notification.Id,
            allergensByNature,
            allergensByCrossContamination);

        await _dbContext.AllergenClassifications.AddAsync(allergenClassification, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}