using DotnetAngularWebProject.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartFormat;

namespace DotnetAngularWebProject.Modules.WeatherForecast.Data.EntityFramework {
    internal sealed class ModuleDbContext : DbContext {
        private readonly IConfiguration configuration;

        public ModuleDbContext(IConfiguration configuration) => this.configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(
                configuration
                    .GetConnectionString(Startup.Module)
                    .FormatSmart(new { FilePath = IStartup.AssemblyPath }));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
