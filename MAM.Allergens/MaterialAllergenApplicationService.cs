using MAM.Shared.Domain;
using MAM.Allergens.Domain;
using MAM.Allergens.DTOs;
using MAM.Allergens.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens;

public interface IMaterialAllergenApplicationService
{
    Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainListAsync(int top, int skip);
    Task<MaterialAllergenDetailsDto> GetDetailsAsync(string id);

    Task<MaterialAllergenDetailsDto> CreateNewMaterialAllergenAsync(
        string materialId,
        string materialName,
        string materialTypeId,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination);
}

public class MaterialAllergenApplicationService : IMaterialAllergenApplicationService
{
    private readonly AllergensDbContext _dbContext;

    public MaterialAllergenApplicationService(AllergensDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainListAsync(int top, int skip)
    {
        var totalCount = await _dbContext.Materials.CountAsync();

        var result = await _dbContext.Materials
            .OrderByDescending(x => x.CreatedOn)
            .Skip(skip)
            .Take(top)
            .ToListAsync();

        var dtos = result.Select(x => new MaterialAllergenMainListDto(x));

        return PaginatedResult<MaterialAllergenMainListDto>.Create(dtos, totalCount, skip);
    }

    public async Task<MaterialAllergenDetailsDto> GetDetailsAsync(string id)
    {
        // todo: proper error handling
        var entity = await _dbContext.Materials.SingleAsync(x => x.Id == id);
        return new(entity);
    }

    public async Task<MaterialAllergenDetailsDto> CreateNewMaterialAllergenAsync(
        string materialId,
        string materialName,
        string materialTypeId,
        string unitOfMeasureCode,
        string unitOfMeasureName,
        decimal initialStock,
        List<string> allergensByNature,
        List<string> allergensByCrossContamination)
    {
        var materialType = await _dbContext.MaterialTypes.SingleAsync(mt => mt.Id == materialTypeId);

        var entity = Material.Create(
            materialId, materialName, materialType, unitOfMeasureCode, unitOfMeasureName, initialStock,
            allergensByNature, allergensByCrossContamination);
        
        await _dbContext.Materials.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return new(entity);
    }
}