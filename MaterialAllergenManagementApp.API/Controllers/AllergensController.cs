using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MaterialAllergenManagementApp.Controllers;

[Authorize]
[ApiController]
[Route("/api/mad-documents")]
public class AllergensController : ControllerBase
{
    public AllergensController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.Delay(1000);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        await Task.Delay(1000);
        return Ok();
    }
}