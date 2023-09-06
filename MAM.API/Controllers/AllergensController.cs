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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var material = await _mediator.Send(new GetMaterialDetailsQuery(id));
        return Ok(material);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewMaterial([FromBody] CreateNewMaterialRequestDto data)
    {
        var material = await _mediator.Send(new CreateNewMaterialCommand(
            data.MaterialId,
            data.MaterialName,
            data.MaterialTypeId,
            data.UnitOfMeasureCode,
            data.UnitOfMeasureName,
            data.InitialStock,
            data.AllergensByNature,
            data.AllergensByCrossContamination
        ));

        return Ok(material);
    }    
}