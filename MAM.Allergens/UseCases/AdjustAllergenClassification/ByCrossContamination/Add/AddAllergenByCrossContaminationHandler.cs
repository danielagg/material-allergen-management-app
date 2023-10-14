using MAM.Allergens.Domain;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.AdjustAllergenClassification.ByCrossContamination.Add;

public class AddAllergenByCrossContaminationHandler : IRequestHandler<AddAllergenByCrossContaminationCommand>
{
    private readonly AllergensDbContext _dbContext;

    public AddAllergenByCrossContaminationHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task Handle(AddAllergenByCrossContaminationCommand request, CancellationToken cancellationToken)
    {
        var allergenClassification = await _dbContext.AllergenClassifications
            .SingleAsync(x => x.MaterialId == request.MaterialId, cancellationToken);

        if (allergenClassification is null)
            throw new AllergenClassificationDoesNotExistException();

        var allergenToAdd = new IndividualAllergen(request.NewAllergenByCrossContamination);
        allergenClassification.AddNewAllergenByCrossContamination(allergenToAdd);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}