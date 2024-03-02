using DotnetAngularWebProject.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DotnetAngularWebProject.Host.Modules {
    public static class Extensions {
        public static IServiceCollection AddModules(this IServiceCollection @this) {
            IEnumerable<AppModule> modules = Directory
                .EnumerateFiles(IStartup.AssemblyPath, $"{Program.Name}.Modules.*.dll")
                .Select(x => Assembly.LoadFrom(x))
                .SelectMany(x => x.GetTypes())
                .Where(x
                    => !x.IsInterface
                        && !x.IsAbstract
                        && x.GetInterfaces().Contains(typeof(IStartup)))
                .Select(x => @this.AddModule(x))
                .ToList();

            @this.AddModuleControllers(modules);

            return @this;
        }

        public static IApplicationBuilder UseModules(this IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env) {
            _ = app
                .ApplicationServices
                .GetRequiredService<IEnumerable<AppModule>>()
                .ForEach(m => m.Startup.Configure(app, env));

            return app;
        }

        public static void ConfigureApp(this IConfigurationBuilder config, IHostEnvironment env) {
            string assemblyPath = IStartup.AssemblyPath;

            _ = Directory
                .EnumerateFiles(assemblyPath, $"*.appsettings.{env.EnvironmentName}.json")
                .ForEach(x => config.AddJsonFile(x));

            _ = config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            _ = Directory
                .EnumerateFiles(assemblyPath, "*.appsettings.json")
                .ForEach(x => config.AddJsonFile(x));

            _ = config
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
        }

        private static AppModule AddModule(this IServiceCollection @this, Type startupType) {
            IStartup startup = (IStartup)Activator.CreateInstance(startupType)!;
            AppModule module = new(startup);

            startup.ConfigureServices(@this);
            _ = @this.AddSingleton(module);

            return module;
        }

        private static void AddModuleControllers(this IServiceCollection @this, IEnumerable<AppModule> modules)
            => @this.AddControllers(options => options.Conventions.Add(new ModuleRoutingConvention(modules)));
    }
}
