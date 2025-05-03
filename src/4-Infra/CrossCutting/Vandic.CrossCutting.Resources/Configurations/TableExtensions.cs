using System.Linq.Expressions;

namespace Vandic.CrossCutting.Resources.Configurations
{
    public static class TableExtensions
    {
        public static IOrderedEnumerable<TSource> OrderByDirection<TSource, TKey>(this IEnumerable<TSource> source, EnumDirection direction, Func<TSource, TKey> keySelector)
        {
            return direction == EnumDirection.Descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }

        public static IOrderedEnumerable<T> OrderByNaturalDirection<T>(
            this IEnumerable<T> source,
            EnumDirection direction,
            Func<T, string> selector)
        {
            var comparer = new NaturalStringComparer<T>(selector);

            return direction == EnumDirection.Descending
                ? source.OrderByDescending(x => x, comparer)
                : source.OrderBy(x => x, comparer);
        }


        public static IQueryable<T> OrderByNaturalDirection<T, TKey>(
            this IQueryable<T> source,
            EnumDirection direction,
            Expression<Func<T, TKey>> keySelector)
        {
            return direction == EnumDirection.Descending
                ? source.OrderByDescending(keySelector)
                : source.OrderBy(keySelector);
        }


    }
}
