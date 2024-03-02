using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetAngularWebProject.WeatherForecast.Data.Entities.Model {
    internal sealed class Configuration : IEntityTypeConfiguration<Domain.Model> {
        public void Configure(EntityTypeBuilder<Domain.Model> builder) {
            _ = builder.Property(e => e.Id).ValueGeneratedNever();
            _ = builder.Property(e => e.Date).IsRequired();
            _ = builder.Property(e => e.TemperatureC).IsRequired();
            _ = builder.Property(e => e.Summary).IsRequired();
        }
    }
}
