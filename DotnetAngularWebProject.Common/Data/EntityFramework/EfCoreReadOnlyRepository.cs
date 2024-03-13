using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace DotnetAngularWebProject.Common.Data.EntityFramework {
    public class EfCoreReadOnlyRepository<TEntityInterface, TEntityImplementation, TDbContext> : BaseEfCoreRepository, IReadOnlyRepository<TEntityInterface>
        where TEntityInterface : IEntity
        where TEntityImplementation : class, TEntityInterface
        where TDbContext : DbContext {
        private protected readonly DbSet<TEntityImplementation> set;

        public EfCoreReadOnlyRepository(TDbContext dbContext) => set = dbContext.Set<TEntityImplementation>();

        public IAsyncEnumerator<TEntityInterface> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => set.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
    }
}
