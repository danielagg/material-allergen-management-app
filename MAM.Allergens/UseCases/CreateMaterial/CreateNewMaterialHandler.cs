using MAM.Allergens.Domain;
using MAM.Allergens.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MAM.Allergens.Domain.AllergenClassification;
using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.Domain.Inventory;
using MAM.Allergens.Domain.MaterialClassification;
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
        await AssertNoMaterialWithTheSameMaterialCodeExistAsync(request.MaterialCode, cancellationToken);

        var materialCode = MaterialCode.Create(request.MaterialCode);
        var materialName = MaterialName.Create(request.ShortMaterialName, request.FullMaterialName);
        var unitOfMeasure = UnitOfMeasure.Create(request.UnitOfMeasureCode, request.UnitOfMeasureName);
        var stock = Stock.CreateInitialStock(unitOfMeasure, request.InitialStock);
        var materialType = await GetMaterialTypeAsync(request.MaterialTypeId, cancellationToken);

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

    private async Task AssertNoMaterialWithTheSameMaterialCodeExistAsync(string requestedMaterialCode,
        CancellationToken cancellationToken)
    {
        var doesMaterialWithTheSameMaterialCodeExists = await _dbContext.Materials
            .AnyAsync(x => x.Code.Value == requestedMaterialCode, cancellationToken);

        if (doesMaterialWithTheSameMaterialCodeExists)
            throw new MaterialAlreadyExistsException(requestedMaterialCode);
    }
    
    private async Task<MaterialType> GetMaterialTypeAsync(string materialTypeId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(materialTypeId))
            throw new MissingMaterialTypeException();
        
        var materialType = await _dbContext.MaterialTypes.SingleOrDefaultAsync(mt =>
            mt.Id == materialTypeId, cancellationToken);
        
        if(materialType is null)
            throw new MaterialTypesDoesNotExistException("Material type is mandatory");
        
        return materialType;
    }
}