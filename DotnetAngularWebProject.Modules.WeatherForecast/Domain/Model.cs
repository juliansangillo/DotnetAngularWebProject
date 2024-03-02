using DotnetAngularWebProject.Common;
using System;

namespace DotnetAngularWebProject.Modules.WeatherForecast.Domain {
    internal sealed class Model : Entity {
        public Model(int id, DateTime date, int temperatureC, string summary) : base(id) {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }

        public DateTime Date { get; }

        public int TemperatureC { get; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; }
    }
}
