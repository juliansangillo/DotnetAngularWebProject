using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace DotnetAngularWebProject.Common {
    public interface IStartup {
        private static string? AssemblyPathCache;
        static string AssemblyPath => AssemblyPathCache ??= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        string ModuleName { get; }

        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
