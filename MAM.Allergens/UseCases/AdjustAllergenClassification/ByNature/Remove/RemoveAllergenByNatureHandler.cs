using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByNature.Remove;

public class RemoveAllergenByNatureHandler : IRequestHandler<RemoveAllergenByNatureCommand>
{
    private readonly AllergensDbContext _dbContext;

    public RemoveAllergenByNatureHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(RemoveAllergenByNatureCommand request, CancellationToken cancellationToken)
    {
        var allergenClassification = await _dbContext.AllergenClassifications
            .SingleOrDefaultAsync(x => x.MaterialId == request.MaterialId, cancellationToken);

        if (allergenClassification is null)
            throw new AllergenClassificationDoesNotExistException();
        
        var allergenToRemove = new IndividualAllergen(request.AllergenByNatureToRemove);
        allergenClassification.RemoveExistingAllergenByNature(allergenToRemove);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}