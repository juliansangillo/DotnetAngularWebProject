using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetAngularWebProject.Modules.WeatherForecast.Data.EntityFramework.Configurations {
    internal sealed class Model : IEntityTypeConfiguration<Domain.Model> {
        private const string TableName = "WeatherForecasts";

        public void Configure(EntityTypeBuilder<Domain.Model> builder) {
            _ = builder.ToTable(TableName);
            _ = builder.Property(e => e.Id).ValueGeneratedNever();
            _ = builder.Property(e => e.Date).IsRequired();
            _ = builder.Property(e => e.TemperatureC).IsRequired();
            _ = builder.Property(e => e.Summary).IsRequired();
        }
    }
}
