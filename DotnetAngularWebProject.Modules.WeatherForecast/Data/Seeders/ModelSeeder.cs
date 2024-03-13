using DotnetAngularWebProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Modules.WeatherForecast.Data.Seeders {
    internal sealed class ModelSeeder : IEntitySeeder {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async ValueTask SeedAsync(IUnitOfWork unitOfWork) {
            Random rng = new();

            _ = Enumerable
                .Range(0, 5)
                .ForEach(async index => {
                    if (await unitOfWork.Repository<Domain.IModel>().NoneAsync(x => x.Id == index))
                        _ = await unitOfWork.Repository<Domain.IModel>().AddAsync(
                            new Domain.Model(
                                id: index,
                                date: DateTime.UtcNow.AddDays(index),
                                temperatureC: rng.Next(-20, 55),
                                summary: Summaries[rng.Next(Summaries.Length)]));
                });

            _ = await unitOfWork.CompleteAsync();
        }
    }
}
