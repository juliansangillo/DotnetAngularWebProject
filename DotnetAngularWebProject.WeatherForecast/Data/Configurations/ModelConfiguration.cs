using DotnetAngularWebProject.WeatherForecast.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetAngularWebProject.WeatherForecast.Data.Configurations {
    internal sealed class ModelConfiguration : IEntityTypeConfiguration<Model> {
        public void Configure(EntityTypeBuilder<Model> builder) {
            _ = builder.Property(e => e.Id).ValueGeneratedNever();
            _ = builder.Property(e => e.Date).IsRequired();
            _ = builder.Property(e => e.TemperatureC).IsRequired();
            _ = builder.Property(e => e.Summary).IsRequired();
        }
    }
}
