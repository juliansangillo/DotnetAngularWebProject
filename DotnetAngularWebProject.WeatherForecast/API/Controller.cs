using DotnetAngularWebProject.WeatherForecast.Data;
using DotnetAngularWebProject.WeatherForecast.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotnetAngularWebProject.WeatherForecast.API {
    [ApiController]
    [Route("[module]/api/[controller]")]
    public class Controller : ControllerBase {
        private readonly ModuleDbContext context;

        public Controller(ModuleDbContext context) => this.context = context;

        [HttpGet]
        public IAsyncEnumerable<Model> GetAsync() => context.WeatherForecasts.AsAsyncEnumerable();
    }
}
