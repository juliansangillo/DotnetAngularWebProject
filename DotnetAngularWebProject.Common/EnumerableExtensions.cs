using System.Linq;
using System.Threading.Tasks;

namespace System.Collections.Generic {
    public static class EnumerableExtensions {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T> action) {
            foreach (T item in @this)
                action(item);

            return @this;
        }

        public static async ValueTask<bool> NoneAsync<T>(this IAsyncEnumerable<T> @this, Func<T, bool> predicate)
            => !await @this.AnyAsync(predicate);
    }
}
