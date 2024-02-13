using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotnetAngularWebProject.API.Modules {
    public sealed class ModuleRoutingConvention : IActionModelConvention {
        private readonly IEnumerable<AppModule> modules;

        public ModuleRoutingConvention(IEnumerable<AppModule> modules) => this.modules = modules;

        public void Apply(ActionModel action) {
            Assembly assembly = action.Controller.ControllerType.Assembly;
            AppModule module = modules.First(m => m.Assembly == assembly);

            action.RouteValues.Add("module", module.Name);
        }
    }
}
