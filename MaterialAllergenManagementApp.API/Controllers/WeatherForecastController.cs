using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaterialAllergenManagementApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        await Task.Delay(1000);
        return Ok();
    }
}