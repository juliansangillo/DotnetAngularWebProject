using DotnetAngularWebProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAngularWebProject.WeatherForecast.Data.Seeders {
    internal sealed class ModelSeeder : IEntitySeeder<ModuleDbContext> {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public void Seed(ModuleDbContext context) {
            Random rng = new();

            _ = Enumerable
                .Range(0, 5)
                .ForEach(index => {
                    if (context.WeatherForecasts.None(x => x.Id == index))
                        _ = context.WeatherForecasts.Add(
                            new Domain.Model(
                                id: index,
                                date: DateTime.Now.AddDays(index),
                                temperatureC: rng.Next(-20, 55),
                                summary: Summaries[rng.Next(Summaries.Length)]));
                });

            _ = context.SaveChanges();
        }
    }
}
