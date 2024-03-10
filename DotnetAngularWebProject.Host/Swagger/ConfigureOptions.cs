using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;

namespace DotnetAngularWebProject.Host.Swagger {
    public class ConfigureOptions : IConfigureOptions<SwaggerGenOptions>, IConfigureOptions<SwaggerUIOptions> {
        private static readonly Func<string, OpenApiInfo> ApiInfo = version => new() {
            Title = Program.Name,
            Version = version,
            Description = "A template of a web project using a .NET, Angular, and SQLite tech stack that is deployed to Azure App Services using CircleCI.",
            Contact = new OpenApiContact {
                Name = "Julian Sangillo",
                Email = "juliansangillo@gmail.com",
            },
        };

        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options) {
            _ = provider
                .ApiVersionDescriptions
                .ForEach(x => options.SwaggerDoc(x.GroupName, ApiInfo(x.GroupName)));
            options.CustomSchemaIds(type => type.FullName);
            options.OperationFilter<TagOperationFilter>();
        }

        public void Configure(SwaggerUIOptions options)
            => provider
                .ApiVersionDescriptions
                .ForEach(
                    x => {
                        options.SwaggerEndpoint($"/swagger/{x.GroupName}/swagger.json", x.GroupName);
                        options.DocExpansion(DocExpansion.None);
                    });
    }

    public static class SwaggerConfigureOptionsExtensions {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureOptions>()
                .AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureOptions>()
                .AddSwaggerGen();
    }
}
