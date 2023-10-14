using MediatR;
using MAM.Materials.UseCases.GetMaterialDetails;
using MAM.Materials.Domain;
using MAM.Materials.Domain.Exceptions;
using MAM.Materials.Domain.MaterialClassification;
using MAM.Materials.Infrastructure;
using MAM.Shared.GlobalEvents;
using Microsoft.EntityFrameworkCore;

namespace MAM.Materials.UseCases.CreateMaterial;

public class CreateNewMaterialHandler : IRequestHandler<CreateNewMaterialCommand, MaterialDetailsDto>
{
    private readonly MaterialsDbContext _dbContext;
    private readonly IMediator _mediator;

    public CreateNewMaterialHandler(MaterialsDbContext dbContext, IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(mediator);
        
        _dbContext = dbContext;
        _mediator = mediator;
    }

    public async Task<MaterialDetailsDto> Handle(CreateNewMaterialCommand request,
        CancellationToken cancellationToken)
    {
        await AssertNoMaterialWithTheSameMaterialCodeExistAsync(request.MaterialCode, cancellationToken);

        var materialCode = MaterialCode.Create(request.MaterialCode);
        var materialName = MaterialName.Create(request.ShortMaterialName, request.FullMaterialName);
        var materialType = await GetMaterialTypeAsync(request.MaterialTypeId, cancellationToken);

        
        var result = Material.Create(materialCode, materialName, materialType);

        result.IfSucc(async material =>
        {
            await _dbContext.Materials.AddAsync(material, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await _mediator.Publish(new NewMaterialCreated(
                material.Id,
                material.Name.FullName,
                request.UnitOfMeasureCode,
                request.UnitOfMeasureName,
                request.InitialStock,
                request.AllergensByNature,
                request.AllergensByCrossContamination), cancellationToken);
        });

        return result.Match<MaterialDetailsDto>(
            material =>new MaterialDetailsDto(material),
            exception => throw exception); // todo: big no-no
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