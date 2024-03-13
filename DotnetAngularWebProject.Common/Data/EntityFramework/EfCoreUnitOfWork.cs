using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAngularWebProject.Common.Data.EntityFramework {
    public class EfCoreUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext {
        private readonly IDictionary<Type, BaseEfCoreRepository> dictionary;
        private readonly TDbContext dbContext;

        public EfCoreUnitOfWork(IEnumerable<BaseEfCoreRepository> repositories, TDbContext dbContext) {
            dictionary = repositories.ToDictionary(x => x.GetType().GenericTypeArguments[0]);
            this.dbContext = dbContext;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : IEntity => (IRepository<TEntity>)dictionary[typeof(TEntity)];

        public async ValueTask<bool> CompleteAsync() => await dbContext.SaveChangesAsync() > 0;
    }

    public static class EfCoreUnitOfWorkExtensions {
        public static IServiceCollection AddEfCoreUnitOfWork<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
            => services
                .AddUnitOfWork<EfCoreUnitOfWork<TDbContext>>()
                .AddDbContext<TDbContext>();

        public static IServiceScope MigrateEfCore<TDbContext>(this IServiceScope scope) where TDbContext : DbContext {
            scope.ServiceProvider
                .GetRequiredService<TDbContext>()
                .Database
                .Migrate();

            return scope;
        }
    }
}
