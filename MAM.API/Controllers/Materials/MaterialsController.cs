using MAM.Allergens.Domain.Exceptions;
using MAM.Materials.UseCases.CreateMaterial;
using MAM.Materials.UseCases.DeleteMaterial;
using MAM.Materials.UseCases.GetMaterialDetails;
using MAM.Materials.Domain.Exceptions;
using MaterialAllergenManagementApp;

namespace MAM.Controllers.Materials;

// [Authorize]
[AllowAnonymous]
[ApiController]
[Route("/api/materials")]
public class MaterialsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IGateway _gateway;
    
    public MaterialsController(IMediator mediator, IGateway gateway)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(gateway);

        _mediator = mediator;
        _gateway = gateway;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? top, [FromQuery] int? skip)
    {
        try
        {
            var result = await _gateway.GetMaterialsMainList(top, skip);
            return Ok(result);
        }
        catch (Exception e)
        {
            return e switch
            {
                AllergenClassificationDoesNotExistException => NotFound(new HttpErrorBody(e)),
                _ => StatusCode(500, new HttpErrorBody("An unexpected error occurred."))
            };
        }
    }

    [HttpGet("{materialId}")]
    public async Task<IActionResult> Get([FromRoute] string materialId)
    {
        try
        {
            var result = await _gateway.GetMaterialDetail(materialId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return e switch
            {
                MaterialDoesNotExistException or 
                    AllergenClassificationDoesNotExistException => NotFound(new HttpErrorBody(e)),
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