using DotnetAngularWebProject.Common;
using DotnetAngularWebProject.Common.API;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAngularWebProject.Modules.WeatherForecast.API.v1 {
    [ApiVersion("1")]
    [Route("[module]/api/v{version:apiVersion}/[controller]")]
    public sealed class Controller : BaseController {
        private readonly IReadOnlyRepository<Domain.IModel> repository;

        public Controller(IReadOnlyRepository<Domain.IModel> repository) => this.repository = repository;

        [HttpGet]
        public IAsyncEnumerable<ModelDto> All()
            => repository
                .Select(
                    x => new ModelDto {
                        Date = x.Date,
                        TemperatureC = x.TemperatureC,
                        TemperatureF = x.TemperatureF,
                        Summary = x.Summary,
                    }
                );
    }
}
