using DotnetAngularWebProject.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DotnetAngularWebProject.Modules.Debug {
    internal sealed class Startup : IStartup {
        public static readonly string Module = typeof(Startup).Namespace!.Split('.').Last();

        public string ModuleName => Module;

        public void ConfigureServices(IServiceCollection services) {
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env) {
        }
    }
}
