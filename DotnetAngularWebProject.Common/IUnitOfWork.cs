using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Common {
    public interface IUnitOfWork {
        IRepository<TEntity> Repository<TEntity>() where TEntity : IEntity;
        ValueTask<bool> CompleteAsync();
    }

    public static class UnitOfWorkExtensions {
        public static IServiceCollection AddUnitOfWork<TUnitOfWork>(this IServiceCollection services) where TUnitOfWork : class, IUnitOfWork
            => services.AddScoped<IUnitOfWork, TUnitOfWork>();
    }
}
