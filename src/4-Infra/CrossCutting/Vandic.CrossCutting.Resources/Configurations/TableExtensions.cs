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
    }
}
