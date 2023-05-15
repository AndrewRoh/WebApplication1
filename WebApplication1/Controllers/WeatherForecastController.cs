using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
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
    
    [HttpGet("{date}", Name = "GetWeatherForecastByDate")]
    public WeatherForecast Get(DateOnly date)
    {
        return new WeatherForecast
        {
            Date = date,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
    
    [HttpPost(Name = "CreateWeatherForecast")]
    public IActionResult Create([FromBody] WeatherForecast weatherForecast)
    {
        return CreatedAtRoute("GetWeatherForecastByDate", new {date = weatherForecast.Date}, weatherForecast);
    }
    
    [HttpPut("{date}", Name = "UpdateWeatherForecast")]
    public IActionResult Update(DateOnly date, [FromBody] WeatherForecast weatherForecast)
    {
        return NoContent();
    }
    
    [HttpDelete("{date}", Name = "DeleteWeatherForecast")]
    public IActionResult Delete(DateOnly date)
    {
        return NoContent();
    }
    
    
}