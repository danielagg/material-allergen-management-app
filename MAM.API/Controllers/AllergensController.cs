using MAM.Allergens.Domain.Exceptions;
using MAM.Allergens.UseCases.ManageAllergenClassification;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Add;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByNature.Remove;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Add;
using MAM.Allergens.UseCases.ManageAllergenClassification.ByCrossContamination.Remove;
using MaterialAllergenManagementApp;

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

    [HttpPost("{materialCode}/allergens-by-nature/add")]
    public async Task<IActionResult> AddNewAllergenByNature([FromRoute] string materialCode, [FromBody] AddNewAllergenRequestDto data)
    {
        try
        {
            var material = await _mediator.Send(new AddAllergenByNatureCommand(materialCode, data.Allergen));
            return Ok(material);
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException => NotFound(new HttpErrorBody(e)),
                CannotAddDuplicateAllergensException => Conflict(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpPost("{materialCode}/allergens-by-nature/remove")]
    public async Task<IActionResult> RemoveNewAllergenByNature([FromRoute] string materialCode, [FromBody] RemoveAllergenRequestDto data)
    {
        try
        {
            var material = await _mediator.Send(new RemoveAllergenByNatureCommand(materialCode, data.Allergen));
            return Ok(material);
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException or
                    CannotRemoveNotPresentAllergensException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpPost("{materialCode}/allergens-by-cross-contamination/add")]
    public async Task<IActionResult> AddNewAllergenByCrossContamination([FromRoute] string materialCode, [FromBody] AddNewAllergenRequestDto data)
    {
        try
        {
            var material = await _mediator.Send(new AddAllergenByCrossContaminationCommand(materialCode, data.Allergen));
            return Ok(material);
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException => NotFound(new HttpErrorBody(e)),
                CannotAddDuplicateAllergensException => Conflict(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpPost("{materialCode}/allergens-by-cross-contamination/remove")]
    public async Task<IActionResult> RemoveNewAllergenByCrossContamination([FromRoute] string materialCode, [FromBody] RemoveAllergenRequestDto data)
    {
        try
        {
            var material = await _mediator.Send(new RemoveAllergenByCrossContaminationCommand(materialCode, data.Allergen));
            return Ok(material);
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException or
                    CannotRemoveNotPresentAllergensException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }    
}