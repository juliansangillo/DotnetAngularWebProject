using DotnetAngularWebProject.Host.Modules;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotnetAngularWebProject.Host.Swagger {
    public class TagOperationFilter : IOperationFilter {
        private readonly IEnumerable<AppModule> modules;

        public TagOperationFilter(IEnumerable<AppModule> modules) => this.modules = modules;

        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            Assembly? assembly = context.MethodInfo.DeclaringType?.Assembly;
            AppModule module = modules.First(m => m.Assembly == assembly);

            operation.Tags = new List<OpenApiTag> {
                new() {
                    Name = module.Name,
                },
            };
        }
    }
}
