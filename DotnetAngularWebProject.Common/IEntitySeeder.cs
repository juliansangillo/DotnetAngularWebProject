using Microsoft.EntityFrameworkCore;

namespace DotnetAngularWebProject.Common {
    public interface IEntitySeeder<TDbContext> where TDbContext : DbContext {
        void Seed(TDbContext db);
    }
}
