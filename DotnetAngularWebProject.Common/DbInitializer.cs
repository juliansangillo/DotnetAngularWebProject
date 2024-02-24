using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotnetAngularWebProject.Common {
    public sealed class DbInitializer<TDbContext> : IDisposable
        where TDbContext : DbContext {
        private readonly IServiceScope scope;
        private readonly TDbContext db;

        public DbInitializer(IApplicationBuilder app) {
            scope = app.ApplicationServices.CreateScope();
            db = scope.ServiceProvider.GetRequiredService<TDbContext>();
        }

        public DbInitializer<TDbContext> Migrate() {
            db
                .Database
                .Migrate();

            return this;
        }

        public DbInitializer<TDbContext> Seed(Assembly assembly) {
            _ = assembly
                .GetTypes()
                .Where(x
                    => !x.IsInterface
                        && !x.IsAbstract
                        && x.GetInterfaces().Contains(typeof(IEntitySeeder<TDbContext>)))
                .Select(x => (IEntitySeeder<TDbContext>)Activator.CreateInstance(x)!)
                .ForEach(x => x.Seed(db));

            return this;
        }

        public void Dispose() => scope.Dispose();
    }

    public static class DbInitializerExtensions {
        public static IApplicationBuilder MigrateAndSeedDatabase<TDbContext>(this IApplicationBuilder app, Assembly assembly)
            where TDbContext : DbContext {
            using DbInitializer<TDbContext> initializer = new(app);

            _ = initializer
                .Migrate()
                .Seed(assembly);

            return app;
        }
    }
}
