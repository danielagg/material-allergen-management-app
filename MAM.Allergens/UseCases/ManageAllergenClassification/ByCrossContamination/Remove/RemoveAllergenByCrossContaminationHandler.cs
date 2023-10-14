using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.UseCases.GetMaterialDetails;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Remove;

public class RemoveAllergenByCrossContaminationHandler : IRequestHandler<RemoveAllergenByCrossContaminationCommand, MaterialAllergenDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public RemoveAllergenByCrossContaminationHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }
    
    public async Task<MaterialAllergenDetailsDto> Handle(RemoveAllergenByCrossContaminationCommand request, CancellationToken cancellationToken)
    {
        var material = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleAsync(x => x.Code.Value == request.MaterialCode, cancellationToken);

        if (material == null)
            throw new MaterialDoesNotExistException(request.MaterialCode);
        
        material.RemoveAllergenByCrossContamination(new Allergen(request.AllergenByCrossContaminationToRemove));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(material);
    }
}