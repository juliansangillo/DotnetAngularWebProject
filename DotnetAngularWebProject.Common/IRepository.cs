using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Common {
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : IEntity {
        ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }

    public static class RepositoryExtensions {
        public static IServiceCollection AddRepository<TEntity, TRepositoryImplementation>(this IServiceCollection services)
            where TEntity : IEntity
            where TRepositoryImplementation : class, IRepository<TEntity>
            => services
                .AddScoped<IRepository<TEntity>, TRepositoryImplementation>()
                .AddScoped<IReadOnlyRepository<TEntity>, TRepositoryImplementation>();
    }
}
