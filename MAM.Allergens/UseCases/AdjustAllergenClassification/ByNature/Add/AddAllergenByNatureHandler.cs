using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByNature.Add;

public class AddAllergenByNatureHandler : IRequestHandler<AddAllergenByNatureCommand>
{
    private readonly AllergensDbContext _dbContext;

    public AddAllergenByNatureHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(AddAllergenByNatureCommand request, CancellationToken cancellationToken)
    {
        var allergenClassification = await _dbContext.AllergenClassifications
            .SingleAsync(x => x.MaterialId == request.MaterialId, cancellationToken);

        if (allergenClassification == null)
            throw new AllergenClassificationDoesNotExistException();
        
        var allergenToAdd = new IndividualAllergen(request.NewAllergenByNature);
        allergenClassification.AddNewAllergenByNature(allergenToAdd);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}