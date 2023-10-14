using MAM.Allergens.UseCases.CreateMaterial;
using MAM.Allergens.UseCases.DeleteMaterial;
using MAM.Allergens.UseCases.GetMaterialDetails;
using MAM.Allergens.UseCases.GetMaterialList;
using MAM.Allergens.Domain.Exceptions;
using MaterialAllergenManagementApp;

namespace MAM.Controllers;

// [Authorize]
[AllowAnonymous]
[ApiController]
[Route("/api/materials")]
public class MaterialsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public MaterialsController(IMediator mediator)
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
        try
        {
            var material = await _mediator.Send(new GetMaterialDetailsQuery(materialCode));
            return Ok(material);
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
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
                MaterialAlreadyExistsException => Conflict(new HttpErrorBody(e)),
                MaterialTypesDoesNotExistException => NotFound(new HttpErrorBody(e)),
                
                InvalidMaterialCodeException or
                    InvalidMaterialNameException or
                    MissingMaterialTypeException => BadRequest(new HttpErrorBody(e)),
                
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
    
    [HttpDelete("{materialCode}")]
    public async Task<IActionResult> DeleteMaterial([FromRoute] string materialCode)
    {
        try
        {
            await _mediator.Send(new DeleteMaterialCommand(materialCode));
            return Ok();
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }
}