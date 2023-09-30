using MAM.Allergens.Domain;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.UseCases.GetMaterialDetails;

namespace MAM.Allergens.UseCases.CreateMaterial;

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
        var materialType = await _dbContext.MaterialTypes.SingleAsync(mt =>
            mt.Id == request.MaterialTypeId, cancellationToken);

        var materialCode = MaterialCode.Create(request.MaterialId);
        var materialName = MaterialName.Create(request.ShortMaterialName, request.FullMaterialName);
        var unitOfMeasure = UnitOfMeasure.Create(request.UnitOfMeasureCode, request.UnitOfMeasureName);
        var stock = Stock.CreateInitialStock(unitOfMeasure, request.InitialStock);
        
        var allergenByNature = AllergenByNature.Create(
            request.AllergensByNature.Select(a => new Allergen(a)).ToList());
        
        var allergenByCrossContamination = AllergenByCrossContamination.Create(
            request.AllergensByCrossContamination.Select(a => new Allergen(a)).ToList());
        
        var result = Material
            .Create(materialCode, materialName, materialType, stock, allergenByNature, allergenByCrossContamination);

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