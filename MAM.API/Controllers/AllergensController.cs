using MAM.Allergens.UseCases.CreateMaterial;
using MAM.Allergens.UseCases.GetMaterialDetails;
using MAM.Allergens.UseCases.GetMaterialList;
using MAM.Allergens.UseCases.ManageAllergenClassification;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Add;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Remove;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Add;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Remove;

namespace MAM.Controllers;

// [Authorize]
[AllowAnonymous]
[ApiController]
[Route("/api/allergens")]
public class AllergensController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AllergensController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);

        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? top, [FromQuery] int? skip)
    {
        var result = await _mediator.Send(new GetMaterialMainListQuery(top ?? 10, skip ?? 0));
        return Ok(result);
    }

    [HttpGet("{materialId}")]
    public async Task<IActionResult> Get([FromRoute] string materialId)
    {
        var material = await _mediator.Send(new GetMaterialDetailsQuery(materialId));
        return Ok(material);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewMaterial([FromBody] CreateNewMaterialRequestDto data)
    {
        var material = await _mediator.Send(new CreateNewMaterialCommand(
            data.MaterialCode,
            data.ShortMaterialName,
            data.FullMaterialName,
            data.MaterialTypeId,
            data.UnitOfMeasureCode,
            data.UnitOfMeasureName,
            data.InitialStock,
            data.AllergensByNature,
            data.AllergensByCrossContamination
        ));

        return Ok(material);
    }
    
    [HttpPost("{materialId}/allergens-by-nature/add")]
    public async Task<IActionResult> AddNewAllergenByNature([FromRoute] string materialId, [FromBody] AddNewAllergenRequestDto data)
    {
        var material = await _mediator.Send(new AddAllergenByNatureCommand(materialId, data.Allergen));
        return Ok(material);
    }
    
    [HttpPost("{materialId}/allergens-by-nature/remove")]
    public async Task<IActionResult> RemoveNewAllergenByNature([FromRoute] string materialId, [FromBody] RemoveAllergenRequestDto data)
    {
        var material = await _mediator.Send(new RemoveAllergenByNatureCommand(materialId, data.Allergen));
        return Ok(material);
    }
    
    [HttpPost("{materialId}/allergens-by-cross-contamination/add")]
    public async Task<IActionResult> AddNewAllergenByCrossContamination([FromRoute] string materialId, [FromBody] AddNewAllergenRequestDto data)
    {
        var material = await _mediator.Send(new AddAllergenByCrossContaminationCommand(materialId, data.Allergen));
        return Ok(material);
    }
    
    [HttpPost("{materialId}/allergens-by-cross-contamination/remove")]
    public async Task<IActionResult> RemoveNewAllergenByCrossContamination([FromRoute] string materialId, [FromBody] RemoveAllergenRequestDto data)
    {
        var material = await _mediator.Send(new RemoveAllergenByCrossContaminationCommand(materialId, data.Allergen));
        return Ok(material);
    }    
}