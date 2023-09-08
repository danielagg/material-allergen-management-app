using MAM.Allergens.Commands;
using MAM.Allergens.Domain;
using MAM.Allergens.DTOs;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using LanguageExt.Common;

namespace MAM.Allergens.Handlers;

public class CreateNewMaterialHandler : IRequestHandler<CreateNewMaterialCommand, MaterialAllergenDetailsDto>
{
    private readonly AllergensDbContext _dbContext;

    public CreateNewMaterialHandler(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MaterialAllergenDetailsDto> Handle(CreateNewMaterialCommand request,
        CancellationToken cancellationToken)
    {
        var materialType = await _dbContext.MaterialTypes.SingleAsync(mt => mt.Id == request.MaterialTypeId, cancellationToken: cancellationToken);

        var result = Material
            .Create(
                request.MaterialId, request.MaterialName, materialType, request.UnitOfMeasureCode,
                request.UnitOfMeasureName, request.InitialStock,
                request.AllergensByNature, request.AllergensByCrossContamination);

        result.IfSucc(async material =>
        {
            await _dbContext.Materials.AddAsync(material, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        });

        return result.Match<MaterialAllergenDetailsDto>(
            material => new MaterialAllergenDetailsDto(material),
            exception => throw exception); // todo: throw...
    }
}