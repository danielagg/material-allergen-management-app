using System.Diagnostics;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Infrastructure;
using MAM.Allergens.UseCases.GetAllergenClassificationOverview;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.UseCases.GetAllergenClassificationDetails;

public class GetAllergenClassificationDetailsHandler : IRequestHandler<GetAllergenClassificationDetailsQuery, AllergenClassificationDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public GetAllergenClassificationDetailsHandler(AllergensDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        
        _dbContext = dbContext;
    }

    public async Task<AllergenClassificationDetailsDto> Handle(
        GetAllergenClassificationDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var allergenClassification = await _dbContext.AllergenClassifications
            .SingleOrDefaultAsync(x => x.MaterialId == request.MaterialId, cancellationToken);

        if (allergenClassification is null)
            throw new AllergenClassificationDoesNotExistException();

        var dto = new AllergenClassificationDetailsDto(
            allergenClassification.MaterialId,
            allergenClassification.ByNatureAllergens.Allergens.Select(a => a.Name).ToList(),
            allergenClassification.CrossContaminatingAllergens.Allergens.Select(a => a.Name).ToList());
        
        return dto;
    }
}