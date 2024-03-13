using DotnetAngularWebProject.Common;
using DotnetAngularWebProject.Common.Data.EntityFramework;
using DotnetAngularWebProject.Modules.WeatherForecast.Data.EntityFramework;
using DotnetAngularWebProject.Modules.WeatherForecast.Data.Seeders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace DotnetAngularWebProject.Modules.WeatherForecast {
    internal sealed class Startup : IStartup {
        public static readonly string Module = typeof(Startup).Namespace!.Split('.').Last();

        public string ModuleName => Module;

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddEfCoreUnitOfWork<ModuleDbContext>()
                .AddEfCoreRepository<Domain.IModel, Domain.Model, ModuleDbContext>();

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env) {
            IServiceScope scope = app.ApplicationServices.CreateScope();

            if (env.IsDevelopment())
                _ = scope
                    .MigrateEfCore<ModuleDbContext>()
                    .Seed<ModelSeeder>();

            scope.Dispose();
        }
    }
}
