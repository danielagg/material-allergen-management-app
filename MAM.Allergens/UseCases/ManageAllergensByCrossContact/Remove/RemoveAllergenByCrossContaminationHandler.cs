using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.UseCases.GetMaterialDetails;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.ManageAllergensByCrossContact.Remove;

public class RemoveAllergenByCrossContaminationHandler : IRequestHandler<RemoveAllergenByCrossContaminationCommand, MaterialAllergenDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public RemoveAllergenByCrossContaminationHandler(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<MaterialAllergenDetailsDto> Handle(RemoveAllergenByCrossContaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleAsync(x => x.Id == request.MaterialId, cancellationToken);

        entity.RemoveAllergenByCrossContamination(new Allergen(request.AllergenByCrossContaminationToRemove));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(entity);
    }
}