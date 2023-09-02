using MaterialAllergenManagementApp.Shared.Domain;
using MaterialAllergenManagementApp.Allergens.DTOs;

namespace MaterialAllergenManagementApp.Allergens;

public interface IMaterialAllergenApplicationService
{
    Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainList(int top, int skip);
}

public class MaterialAllergenApplicationService : IMaterialAllergenApplicationService
{

    public async Task<PaginatedResult<MaterialAllergenMainListDto>> GetPaginatedMainList(int top, int skip)
    {
        await Task.Delay(1000);
        return PaginatedResult<MaterialAllergenMainListDto>.Empty();
    }
}