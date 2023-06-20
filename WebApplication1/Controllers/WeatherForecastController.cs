using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebApplication1.AOP.Interceptors;
using WebApplication1.MiddleWare;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<WeatherForecast> _localizer;
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly GetDataClass _getDataClass;

        private readonly ISingletonService _singletonService;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<WeatherForecast> localizer, ITransientService transientService, IScopedService scopedService, ISingletonService singletonService, GetDataClass getDataClass)
        {
            _logger = logger;
            _localizer = localizer;
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
            _getDataClass = getDataClass;
        }

        [HttpGet]
        public string Get()
        {
            _transientService.Say("调用transientService");
            _scopedService.Say("调用scopedService");
            _singletonService.Say("调用SingletonService");
            var time= _getDataClass.GetTime();
            return time;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}