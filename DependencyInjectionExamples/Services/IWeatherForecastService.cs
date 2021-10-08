using System;
using System.Collections.Generic;

namespace DependencyInjectionExamples.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> GetBySummary(string summary);
    }
}
