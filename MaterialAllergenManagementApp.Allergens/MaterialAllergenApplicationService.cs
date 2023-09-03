using MaterialAllergenManagementApp.Shared.Domain;
using MaterialAllergenManagementApp.Allergens.DTOs;
using MaterialAllergenManagementApp.Allergens.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MaterialAllergenManagementApp.Allergens;

public interface IMaterialAllergenApplicationService
{
    Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainListAsync(int top, int skip);
    Task<MaterialAllergenDetailsDto> GetDetailsAsync(string id);

    Task<MaterialAllergenDetailsDto> CreateNewMaterialAllergenAsync(
        string materialId,
        string materialName,
        bool allergenByNature,
        bool allergenByCrossContamination);
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

        return new PaginatedResult<MaterialAllergenMainListDto>(dtos, totalCount, result.Count, skip);
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
        bool allergenByNature,
        bool allergenByCrossContamination)
    {
        var entity = Material.Create(materialId, materialName, allergenByNature, allergenByCrossContamination);
        
        await _dbContext.Materials.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return new(entity);
    }
}