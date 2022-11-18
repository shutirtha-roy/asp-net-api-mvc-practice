using FirstDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemo.API.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICourseService _courseService;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize(Policy = "CourseViewRequirementPolicy")]
        public IEnumerable<WeatherForecast> Get()
        {
            var service = _courseService;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}