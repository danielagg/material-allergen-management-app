using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.UseCases.CreateMaterial;
using MAM.Allergens.UseCases.DeleteMaterial;
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

    [HttpGet("{materialCode}")]
    public async Task<IActionResult> Get([FromRoute] string materialCode)
    {
        var material = await _mediator.Send(new GetMaterialDetailsQuery(materialCode));
        return Ok(material);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewMaterial([FromBody] CreateNewMaterialRequestDto data)
    {
        try
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
        catch (Exception e)
        {
            return e switch
            {
                MaterialAlreadyExistsException duplicateEntityEx => Conflict(
                    new { message = duplicateEntityEx.Message }),
                
                _ => StatusCode(500, new { message = "An unexpected error occurred." })
            };
        }
    }
    
    [HttpDelete("{materialCode}")]
    public async Task<IActionResult> DeleteMaterial([FromRoute] string materialCode)
    {
        await _mediator.Send(new DeleteMaterialCommand(materialCode));
        return Ok();
    }
    
    [HttpPost("{materialCode}/allergens-by-nature/add")]
    public async Task<IActionResult> AddNewAllergenByNature([FromRoute] string materialCode, [FromBody] AddNewAllergenRequestDto data)
    {
        var material = await _mediator.Send(new AddAllergenByNatureCommand(materialCode, data.Allergen));
        return Ok(material);
    }
    
    [HttpPost("{materialCode}/allergens-by-nature/remove")]
    public async Task<IActionResult> RemoveNewAllergenByNature([FromRoute] string materialCode, [FromBody] RemoveAllergenRequestDto data)
    {
        var material = await _mediator.Send(new RemoveAllergenByNatureCommand(materialCode, data.Allergen));
        return Ok(material);
    }
    
    [HttpPost("{materialCode}/allergens-by-cross-contamination/add")]
    public async Task<IActionResult> AddNewAllergenByCrossContamination([FromRoute] string materialCode, [FromBody] AddNewAllergenRequestDto data)
    {
        var material = await _mediator.Send(new AddAllergenByCrossContaminationCommand(materialCode, data.Allergen));
        return Ok(material);
    }
    
    [HttpPost("{materialCode}/allergens-by-cross-contamination/remove")]
    public async Task<IActionResult> RemoveNewAllergenByCrossContamination([FromRoute] string materialCode, [FromBody] RemoveAllergenRequestDto data)
    {
        var material = await _mediator.Send(new RemoveAllergenByCrossContaminationCommand(materialCode, data.Allergen));
        return Ok(material);
    }    
}