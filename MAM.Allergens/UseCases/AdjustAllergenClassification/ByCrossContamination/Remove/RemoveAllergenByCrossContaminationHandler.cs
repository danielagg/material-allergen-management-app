using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByCrossContamination.Remove;

public class RemoveAllergenByCrossContaminationHandler : IRequestHandler<RemoveAllergenByCrossContaminationCommand>
{
    private readonly AllergensDbContext _dbContext;

    public RemoveAllergenByCrossContaminationHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(RemoveAllergenByCrossContaminationCommand request, CancellationToken cancellationToken)
    {
        var allergenClassification = await _dbContext.AllergenClassifications
            .SingleOrDefaultAsync(x => x.MaterialId == request.MaterialId, cancellationToken);

        if (allergenClassification is null)
            throw new AllergenClassificationDoesNotExistException();

        var allergenToRemove = new IndividualAllergen(request.AllergenByCrossContaminationToRemove);
        allergenClassification.RemoveExistingAllergenByCrossContamination(allergenToRemove);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}