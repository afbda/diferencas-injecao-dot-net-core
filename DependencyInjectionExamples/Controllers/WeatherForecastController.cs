using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExamples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionExamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IServiceProvider _serviceProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromServices] IWeatherForecastService weatherForecastService)
        {
            //Aqui o serviço é injetado diretamente como parâmetro da função, para isso usamos o atributo FromServices
            return weatherForecastService.Get();
        }

        [HttpGet("{summary}")]
        public IEnumerable<WeatherForecast> GetBySummary(string summary)
        {
            //Aqui usamos o service provider para criar uma nova instância do nosso serviço.
            IWeatherForecastService weatherForecastService = _serviceProvider.GetRequiredService<IWeatherForecastService>();
            return weatherForecastService.GetBySummary(summary);
        }
    }
}
