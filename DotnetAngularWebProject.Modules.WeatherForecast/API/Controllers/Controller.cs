using DotnetAngularWebProject.Modules.WeatherForecast.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAngularWebProject.Modules.WeatherForecast.API.Controllers {
    [ApiController]
    [Route("[module]/api/[controller]")]
    public class Controller : ControllerBase {
        private readonly ModuleDbContext db;

        public Controller(ModuleDbContext db) => this.db = db;

        [HttpGet]
        public IAsyncEnumerable<ModelDto> GetAsync()
            => db
                .WeatherForecasts
                .Select(
                    x => new ModelDto {
                        Date = x.Date,
                        TemperatureC = x.TemperatureC,
                        TemperatureF = x.TemperatureF,
                        Summary = x.Summary,
                    }
                )
                .AsAsyncEnumerable();
    }
}
