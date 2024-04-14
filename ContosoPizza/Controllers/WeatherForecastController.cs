using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController] // This attribute includes several opinionated API-specific behaviors, such as automatic handling for bad HTTP requests.
[Route("[controller]")]  //Route atribute sends HTTP request to associated controller
public class WeatherForecastController : ControllerBase //"WeatherForecastController" the prefix before "Controller" determines the web directory
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

    [HttpGet(Name = "GetWeatherForecast")] // this atribute routes the HTTP GET request to following method:
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
