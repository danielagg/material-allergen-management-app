using MAM.Allergens.Commands;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.DTOs;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Handlers;

public class AddAllergenByNatureHandler : IRequestHandler<AddAllergenByNatureCommand, MaterialAllergenDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public AddAllergenByNatureHandler(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<MaterialAllergenDetailsDto> Handle(AddAllergenByNatureCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Materials
            .Include(x => x.Type)
            .SingleAsync(x => x.Id == request.MaterialId, cancellationToken);

        entity.AddNewAllergenByNature(new Allergen(request.NewAllergenByNature));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(entity);
    }
}