using DotnetAngularWebProject.Common;
using System.Reflection;

namespace DotnetAngularWebProject.API.Modules {
    public class AppModule {
        public AppModule(IStartup startup) => Startup = startup;

        public IStartup Startup { get; }

        public string Name => Startup.ModuleName;

        public Assembly Assembly => Startup.GetType().Assembly;
    }
}
