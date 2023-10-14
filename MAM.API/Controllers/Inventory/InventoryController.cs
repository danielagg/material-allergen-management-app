namespace MAM.Controllers.Inventory;

// [Authorize]
[AllowAnonymous]
[ApiController]
[Route("/api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public InventoryController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);

        _mediator = mediator;
    }
    
    [HttpGet("{materialId}")]
    public async Task<IActionResult> Get([FromRoute] string materialId)
    {
        await Task.Delay(100);
        throw new NotImplementedException();
    }
}