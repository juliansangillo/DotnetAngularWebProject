using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Common.Data.EntityFramework {
    public class EfCoreRepository<TEntityInterface, TEntityImplementation, TDbContext>
        : EfCoreReadOnlyRepository<TEntityInterface, TEntityImplementation, TDbContext>,
        IRepository<TEntityInterface>
        where TEntityInterface : IEntity
        where TEntityImplementation : class, TEntityInterface
        where TDbContext : DbContext {
        public EfCoreRepository(TDbContext dbContext) : base(dbContext) {
        }

        public async ValueTask<TEntityInterface> AddAsync(TEntityInterface entity, CancellationToken cancellationToken = default) {
            _ = await set.AddAsync((TEntityImplementation)entity, cancellationToken);
            return entity;
        }
    }

    public static class EfCoreRepositoryExtensions {
        public static IServiceCollection AddEfCoreRepository<TEntityInterface, TEntityImplementation, TDbContext>(this IServiceCollection services)
            where TEntityInterface : IEntity
            where TEntityImplementation : class, TEntityInterface
            where TDbContext : DbContext
            => services
                .AddRepository<TEntityInterface, EfCoreRepository<TEntityInterface, TEntityImplementation, TDbContext>>()
                .AddScoped<BaseEfCoreRepository, EfCoreRepository<TEntityInterface, TEntityImplementation, TDbContext>>();
    }
}
