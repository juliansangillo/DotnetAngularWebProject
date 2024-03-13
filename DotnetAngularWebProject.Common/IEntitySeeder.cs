using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Common {
    public interface IEntitySeeder {
        ValueTask SeedAsync(IUnitOfWork unitOfWork);
    }

    public static class ApplicationBuilderExtensions {
        public static IServiceScope Seed<TEntitySeeder>(this IServiceScope scope)
            where TEntitySeeder : class, IEntitySeeder {
            ((IEntitySeeder)Activator.CreateInstance(typeof(TEntitySeeder))!)
               .SeedAsync(
                   scope.ServiceProvider
                       .GetRequiredService<IUnitOfWork>())
               .AsTask()
               .GetAwaiter()
               .GetResult();

            return scope;
        }
    }
}
