using MaterialAllergenManagementApp.Shared.Domain;
using MaterialAllergenManagementApp.Allergens.DTOs;

namespace MaterialAllergenManagementApp.Allergens;

public interface IMaterialAllergenApplicationService
{
    Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainListAsync(int top, int skip);
    Task<MaterialAllergenDetailsDto> GetDetailsAsync(string id);
}

public class MaterialAllergenApplicationService : IMaterialAllergenApplicationService
{

    public async Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainListAsync(int top, int skip)
    {
        await Task.Delay(1000);
        return PaginatedResult<MaterialAllergenMainListDto>.Empty();
    }

    public async Task<MaterialAllergenDetailsDto> GetDetailsAsync(string id)
    {
        await Task.Delay(1000);
        return null;
    }
}