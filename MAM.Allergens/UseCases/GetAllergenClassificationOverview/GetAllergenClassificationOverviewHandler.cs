using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.GetAllergenClassificationOverview;

public class GetAllergenClassificationOverviewHandler : IRequestHandler<GetAllergenClassificationOverviewQuery, List<AllergenClassificationOverviewDto>>
{
    private readonly AllergensDbContext _dbContext;

    public GetAllergenClassificationOverviewHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }

    public async Task<List<AllergenClassificationOverviewDto>> Handle(
        GetAllergenClassificationOverviewQuery request,
        CancellationToken cancellationToken)
    {
        var allergenClassifications = await _dbContext.AllergenClassifications
            .Where(x => request.MaterialIds.Contains(x.MaterialId))
            .ToListAsync(cancellationToken);

        var foundMaterialIds = allergenClassifications.Select(x => x.MaterialId);
        
        // make sure we have as many allergen classifications as requested
        if (request.MaterialIds.Except(foundMaterialIds).Any())
            throw new AllergenClassificationDoesNotExistException();

        var dtos = allergenClassifications
            .Select(x => new AllergenClassificationOverviewDto(
                x.MaterialId,
                x.HasAllergensByNature(),
                x.HasAllergensByCrossContamination()))
            .ToList();
        
        return dtos;
    }
}