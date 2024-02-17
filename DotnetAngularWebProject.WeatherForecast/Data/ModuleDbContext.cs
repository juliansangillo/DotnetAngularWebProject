using DotnetAngularWebProject.Common;
using DotnetAngularWebProject.WeatherForecast.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartFormat;

namespace DotnetAngularWebProject.WeatherForecast.Data {
    public sealed class ModuleDbContext : DbContext {
        private readonly IConfiguration configuration;

        public ModuleDbContext(IConfiguration configuration) => this.configuration = configuration;

        internal DbSet<Model> WeatherForecasts { get; private set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(
                configuration
                    .GetConnectionString(Startup.Module)
                    .FormatSmart(new { FilePath = IStartup.AssemblyPath }));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
