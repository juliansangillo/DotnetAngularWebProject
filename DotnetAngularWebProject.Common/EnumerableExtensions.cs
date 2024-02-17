using System.Linq;

namespace System.Collections.Generic {
    public static class EnumerableExtensions {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> @this, Action<T> action) {
            foreach (T item in @this)
                action(item);

            return @this;
        }

        public static bool None<T>(this IEnumerable<T> @this, Func<T, bool> predicate)
            => !@this.Any(predicate);
    }
}
