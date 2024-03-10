using System;

namespace DotnetAngularWebProject.Modules.WeatherForecast.API.v1 {
    public sealed class ModelDto {
        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public int TemperatureF { get; init; }

        public string? Summary { get; init; }
    }
}
