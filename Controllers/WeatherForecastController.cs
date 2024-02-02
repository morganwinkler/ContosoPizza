using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

// [ApiController] enables opinionated behaviors that make it easier to build web APIs. Some behaviors include parameter source inference, attribute routing as a requirement, and model validation error-handlingenhancements*.
[ApiController]
// [Route] defines the routing pattern [controller]. The controller's name (case-insensitive, without the Controller suffix) replaces the [controller] token. This controller handles requests to https://localhost:{PORT}/weatherforecast. The route might contain static strings, as in api/[controller]. In this example, this controller would handle a request to https://localhost:{PORT}/api/weatherforecast.
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

  private readonly ILogger<WeatherForecastController> _logger;

  public WeatherForecastController(ILogger<WeatherForecastController> logger)
  {
    _logger = logger;
  }

  [HttpGet(Name = "GetWeatherForecast")]
  public IEnumerable<WeatherForecast> Get()
  {
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
    .ToArray();
  }
}
