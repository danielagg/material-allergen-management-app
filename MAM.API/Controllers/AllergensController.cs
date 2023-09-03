using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MAM.Allergens;
using MAM.Allergens.DTOs;

namespace MAM.Controllers;

// [Authorize]
[AllowAnonymous]
[ApiController]
[Route("/api/allergens")]
public class AllergensController : ControllerBase
{
    private readonly IMaterialAllergenApplicationService _appService;
    
    public AllergensController(
        IMaterialAllergenApplicationService appService
    )
    {
        ArgumentNullException.ThrowIfNull(appService);

        _appService = appService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? top, [FromQuery] int? skip)
    {
        var result = await _appService.GetPaginatedMainListAsync(top ?? 10, skip ?? 0);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var result = await _appService.GetDetailsAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewMaterial([FromBody] CreateNewMaterialDto data)
    {
        var result = await _appService.CreateNewMaterialAllergenAsync(
            data.MaterialId,
            data.MaterialName,
            data.MaterialTypeId,
            data.UnitOfMeasureCode,
            data.UnitOfMeasureName,
            data.InitialStock,
            data.AllergensByNature,
            data.AllergensByCrossContamination);

        return Ok(result);
    }    
}