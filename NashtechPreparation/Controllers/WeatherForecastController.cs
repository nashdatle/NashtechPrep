using Microsoft.AspNetCore.Mvc;

namespace NashtechPreparation.Controllers
{
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

        [HttpGet("/Summaries")]
        public IEnumerable<string> GetSummaries()
        {
            return Summaries.ToList();
        }

        [HttpGet("/Summary/{id}")]
        public string GetSummaries(int id)
        {
            try
            {
                return Summaries.GetValue(id).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("/Add")]
        public IActionResult AddWeatherForecast(WeatherForecast weatherForecast)
        {
            if (ModelState.IsValid)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}
