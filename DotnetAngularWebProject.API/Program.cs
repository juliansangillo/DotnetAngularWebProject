using DotnetAngularWebProject.API.Modules;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace DotnetAngularWebProject.API {
    public class Program {
        public static readonly string Name = typeof(Program).Namespace!.Split('.').First();

        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) => config.ConfigureApp(context.HostingEnvironment))
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
