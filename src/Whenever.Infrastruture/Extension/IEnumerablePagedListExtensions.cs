using System.Linq.Dynamic.Core;
using Whenever.Infrastruture.Collection;

namespace Whenever.Infrastruture.Extension;

public static class EnumerablePagedListExtensions
{
    public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize,
        int indexFrom = 0)
    {
        return new PagedList<T>(source, pageIndex, pageSize, indexFrom);
    }

    public static IPagedList<TResult> ToPagedList<TSource, TResult>(this IEnumerable<TSource> source,
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int pageIndex, int pageSize, int indexFrom = 0)
    {
        return new PagedList<TSource, TResult>(source, converter, pageIndex, pageSize, indexFrom);
    }

    /// <summary>
    ///     Filters the collection using a search keyword across multiple properties.
    /// </summary>
    public static IEnumerable<T> ApplySearch<T>(this IEnumerable<T> source, string keyword,
        params string[] searchProperties)
    {
        if (string.IsNullOrWhiteSpace(keyword) || searchProperties == null || !searchProperties.Any())
            return source;

        var predicate = string.Join(" OR ", searchProperties.Select(p => $"{p}.ToString().Contains(@0)"));
        return source.AsQueryable().Where(predicate, keyword);
    }

    /// <summary>
    ///     Sorts the collection based on multiple sort expressions. E.g. "Name asc, CreatedAt desc"
    /// </summary>
    public static IEnumerable<T> ApplySort<T>(this IEnumerable<T> source, string sorts)
    {
        if (string.IsNullOrWhiteSpace(sorts))
            return source;

        return source.AsQueryable().OrderBy(sorts);
    }
}