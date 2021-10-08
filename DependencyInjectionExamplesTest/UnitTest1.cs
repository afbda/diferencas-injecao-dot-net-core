using System;
using System.Collections.Generic;
using DependencyInjectionExamples;
using DependencyInjectionExamples.Controllers;
using DependencyInjectionExamples.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DependencyInjectionExamplesTest
{
    public class UnitTest1
    {
        private readonly Mock<ILogger<WeatherForecastController>> loggerMock = new Mock<ILogger<WeatherForecastController>>();
        private readonly Mock<IServiceProvider> serviceProviderMock = new Mock<IServiceProvider>();
        private readonly Mock<IWeatherForecastService> weatherForecastServiceMock = new Mock<IWeatherForecastService>();
        [Fact]
        public void ShouldReturnAWeatherForecastArray()
        {
            var controller = new WeatherForecastController(loggerMock.Object, serviceProviderMock.Object);
            weatherForecastServiceMock.Setup(x => x.Get()).Returns(new List<WeatherForecast>() { new WeatherForecast() { Date = DateTime.Now, Summary = "Test", TemperatureC = 10 } });
            Assert.NotEmpty(controller.Get(weatherForecastServiceMock.Object));
        }
    }
}
