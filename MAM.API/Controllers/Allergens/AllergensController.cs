using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.UseCases.AdjustAllergenClassification;
using MAM.Allergens.UseCases.AdjustAllergenClassification.ByNature.Add;
using MAM.Allergens.UseCases.AdjustAllergenClassification.ByNature.Remove;
using MAM.Allergens.UseCases.AdjustAllergenClassification.ByCrossContamination.Add;
using MAM.Allergens.UseCases.AdjustAllergenClassification.ByCrossContamination.Remove;
using MaterialAllergenManagementApp;

namespace MAM.Controllers.Allergens;

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

    [HttpPost("{materialId}/allergens-by-nature/add")]
    public async Task<IActionResult> AddNewAllergenByNature([FromRoute] string materialId, [FromBody] AddNewAllergenRequestDto data)
    {
        try
        {
            await _mediator.Send(new AddAllergenByNatureCommand(materialId, data.Allergen));
            return Ok();
        }
        catch (Exception e)
        {
            return e switch
            {
                AllergenClassificationDoesNotExistException => NotFound(new HttpErrorBody(e)),
                CannotAddDuplicateAllergensException => Conflict(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpPost("{materialId}/allergens-by-nature/remove")]
    public async Task<IActionResult> RemoveNewAllergenByNature([FromRoute] string materialId, [FromBody] RemoveAllergenRequestDto data)
    {
        try
        {
            await _mediator.Send(new RemoveAllergenByNatureCommand(materialId, data.Allergen));
            return Ok();
        }
        catch (Exception e)
        {
            return e switch
            {
                AllergenClassificationDoesNotExistException or
                    CannotRemoveNotPresentAllergensException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpPost("{materialId}/allergens-by-cross-contamination/add")]
    public async Task<IActionResult> AddNewAllergenByCrossContamination([FromRoute] string materialId, [FromBody] AddNewAllergenRequestDto data)
    {
        try
        {
            await _mediator.Send(new AddAllergenByCrossContaminationCommand(materialId, data.Allergen));
            return Ok();
        }
        catch (Exception e)
        {
            return e switch
            {
                AllergenClassificationDoesNotExistException => NotFound(new HttpErrorBody(e)),
                CannotAddDuplicateAllergensException => Conflict(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpPost("{materialId}/allergens-by-cross-contamination/remove")]
    public async Task<IActionResult> RemoveNewAllergenByCrossContamination([FromRoute] string materialId, [FromBody] RemoveAllergenRequestDto data)
    {
        try
        {
            await _mediator.Send(new RemoveAllergenByCrossContaminationCommand(materialId, data.Allergen));
            return Ok();
        }
        catch (Exception e)
        {
            return e switch
            {
                AllergenClassificationDoesNotExistException or
                    CannotRemoveNotPresentAllergensException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }    
}