using DotnetAngularWebProject.Host.Middleware;
using DotnetAngularWebProject.Host.Modules;
using DotnetAngularWebProject.Host.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotnetAngularWebProject.Host {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            _ = services.AddModules();
            _ = services.AddSwagger();
            _ = services.AddApiVersioning(
                o => {
                    o.ReportApiVersions = true;
                    o.ApiVersionReader = new UrlSegmentApiVersionReader();
                });
            _ = services.AddVersionedApiExplorer(
                o => {
                    o.GroupNameFormat = "'v'VVV";
                    o.SubstituteApiVersionInUrl = true;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
                _ = app
                    .UseSwagger()
                    .UseSwaggerUI();

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
