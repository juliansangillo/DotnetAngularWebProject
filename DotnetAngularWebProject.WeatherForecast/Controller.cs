using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAngularWebProject.WeatherForecast {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "ASP.NET Controller methods must be non-static")]
    [ApiController]
    [Route("api/WeatherForecast")]
    public class Controller : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Controller> logger;

        public Controller(ILogger<Controller> logger) => this.logger = logger;

        [HttpGet]
        public IEnumerable<Entity> Get() {
            Random rng = new();
            return Enumerable.Range(1, 5).Select(index => new Entity {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
