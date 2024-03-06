using DotnetAngularWebProject.Host.Middleware;
using DotnetAngularWebProject.Host.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DotnetAngularWebProject.Host {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            _ = services.AddModules();
            _ = services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Program.Name, Version = "v1" });
                c.CustomSchemaIds(type => type.FullName);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                _ = app
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Program.Name} v1"));
            }

            _ = app
                .UseJsonExceptionPage()
                .UseModules(env)
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
