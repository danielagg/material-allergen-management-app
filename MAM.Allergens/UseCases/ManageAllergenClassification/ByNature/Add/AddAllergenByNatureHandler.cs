using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.UseCases.GetMaterialDetails;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Add;

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
            .SingleAsync(x => x.Code.Value == request.MaterialCode, cancellationToken);

        entity.AddNewAllergenByNature(new Allergen(request.NewAllergenByNature));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(entity);
    }
}