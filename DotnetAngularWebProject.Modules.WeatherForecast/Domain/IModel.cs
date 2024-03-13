using DotnetAngularWebProject.Common;
using System;

namespace DotnetAngularWebProject.Modules.WeatherForecast.Domain {
    public interface IModel : IEntity {
        DateTime Date { get; }

        int TemperatureC { get; }

        int TemperatureF { get; }

        string Summary { get; }
    }
}
