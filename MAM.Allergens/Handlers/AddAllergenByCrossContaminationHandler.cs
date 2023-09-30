using MAM.Allergens.Commands;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.DTOs;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Handlers;

public class AddAllergenByCrossContaminationHandler : IRequestHandler<AddAllergenByCrossContaminationCommand, MaterialAllergenDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public AddAllergenByCrossContaminationHandler(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<MaterialAllergenDetailsDto> Handle(AddAllergenByCrossContaminationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleAsync(x => x.Id == request.MaterialId, cancellationToken);

        entity.AddNewAllergenByCrossContamination(new Allergen(request.NewAllergenByCrossContamination));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(entity);
    }
}