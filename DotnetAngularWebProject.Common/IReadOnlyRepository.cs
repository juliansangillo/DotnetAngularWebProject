using System.Collections.Generic;

namespace DotnetAngularWebProject.Common {
    public interface IReadOnlyRepository<TEntity> : IAsyncEnumerable<TEntity> where TEntity : IEntity {
    }
}
