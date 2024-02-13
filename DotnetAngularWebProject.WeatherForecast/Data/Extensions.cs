using DotnetAngularWebProject.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DotnetAngularWebProject.WeatherForecast.Data {
    internal static class Extensions {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static IServiceScope SeedDatabase(this IServiceScope scope) {
            ModuleDbContext context = scope.ServiceProvider.GetRequiredService<ModuleDbContext>();
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

            return scope;
        }

        public static IServiceScope MigrateDatabase(this IServiceScope scope) {
            scope
                .ServiceProvider
                .GetRequiredService<ModuleDbContext>()
                .Database
                .Migrate();

            return scope;
        }
    }
}
