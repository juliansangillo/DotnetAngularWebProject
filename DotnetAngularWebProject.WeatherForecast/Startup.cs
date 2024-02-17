using DotnetAngularWebProject.Common;
using DotnetAngularWebProject.WeatherForecast.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace DotnetAngularWebProject.WeatherForecast {
    public sealed class Startup : IStartup {
        public static readonly string Module = typeof(Startup).Namespace!.Split('.').Last();

        public string ModuleName => Module;

        public void ConfigureServices(IServiceCollection services) => services.AddDbContext<ModuleDbContext>();

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env) {
            if (env.IsDevelopment())
                _ = app.MigrateAndSeedDatabase<ModuleDbContext>(GetType().Assembly);
        }
    }
}
