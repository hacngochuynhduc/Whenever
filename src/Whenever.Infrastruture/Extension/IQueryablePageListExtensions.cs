using System.Collections;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Whenever.Infrastruture.Collection;

namespace Whenever.Infrastruture.Extension;

public static class QueryablePageListExtensions
{
    public static async Task<IPagedList<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        int pageIndex,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var pagedList = new PagedList<T>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalCount = count,
            Items = items,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };

        return pagedList;
    }

    /// <summary>
    ///     Applies keyword-based search on multiple fields (case-insensitive).
    /// </summary>
    public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, string keyword, params string[] properties)
    {
        if (string.IsNullOrWhiteSpace(keyword) || properties == null || !properties.Any())
            return query;
        var lowerKeyword = keyword.ToLower();
        var predicate = string.Join(" OR ", properties.Select(p => $"{p}.ToString().ToLower().Contains(@0)"));
        return query.Where(predicate, lowerKeyword);
    }

    /// <summary>
    ///     Applies multiple sort conditions like "Name asc, CreatedAt desc".
    /// </summary>
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string sorts)
    {
        if (string.IsNullOrWhiteSpace(sorts))
            return query;

        return query.OrderBy(sorts);
    }

    /// <summary>
    ///     request.Search = "dây cột";
    ///     request.SearchFields = new List<string> { "Brand.BrandName", "ProductName" };
    /// </summary>
    /// <param name="query"></param>
    /// <param name="searchTerm"></param>
    /// <param name="fields"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, string searchTerm, List<string> fields)
    {
        if (string.IsNullOrWhiteSpace(searchTerm) || fields == null || !fields.Any())
            return query;


        var lowerSearchTerm = searchTerm.ToLower();
        var processedFields = fields
            .Where(f => !string.IsNullOrWhiteSpace(f))
            .Select(f => f.Replace("?", string.Empty))
            .ToList();

        if (!processedFields.Any())
            return query;
        var conditions = processedFields
            .Select(f => $"{f}.ToLower().Contains(@0)")
            .ToArray();

        var predicate = string.Join(" OR ", conditions);
        return query.Where(predicate, lowerSearchTerm);
    }


    /// <summary>
    ///     Applies multiple sort conditions like "Name asc, CreatedAt desc".
    /// </summary>
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, IEnumerable<string> sorts)
    {
        var enumerable = sorts as string[] ?? sorts.ToArray();
        // "Brand.BrandName desc, ProductName asc"
        var sortExpression = string.Join(", ", enumerable);
        return query.OrderBy(sortExpression);
    }

    /// <summary>
    ///     Applies filter conditions based on a dictionary of field names and a list of filter values (IN condition).
    ///     Example: filter = { "Status": ["Active", "Inactive"], "CategoryId": ["1", "5"] }
    /// </summary>
    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Dictionary<string, List<string>> filters)
    {
        if (filters == null || !filters.Any())
            return query;

        foreach (var (field, values) in filters)
        {
            if (values == null || !values.Any())
                continue;

            var nonNullValues = values.Where(v => !string.IsNullOrWhiteSpace(v)).ToList();
            if (!nonNullValues.Any())
                continue;

            var propType = GetPropertyType(typeof(T), field);
            var targetType = propType == null ? typeof(string) : Nullable.GetUnderlyingType(propType) ?? propType;

            object paramValues;

            if (targetType.IsEnum)
            {
                var listType = typeof(List<>).MakeGenericType(targetType);
                var list = (IList)Activator.CreateInstance(listType)!;
                foreach (var s in nonNullValues)
                    try
                    {
                        object enumVal;
                        if (int.TryParse(s, out var n))
                            enumVal = Enum.ToObject(targetType, n);
                        else
                            enumVal = Enum.Parse(targetType, s, true);
                        list.Add(enumVal);
                    }
                    catch
                    {
                        // ignore invalid enum value
                    }

                paramValues = list;
            }
            else if (targetType == typeof(Guid))
            {
                var list = new List<Guid>();
                foreach (var s in nonNullValues)
                    if (Guid.TryParse(s, out var g))
                        list.Add(g);
                paramValues = list;
            }
            else if (targetType == typeof(int))
            {
                var list = new List<int>();
                foreach (var s in nonNullValues)
                    if (int.TryParse(s, out var n))
                        list.Add(n);
                paramValues = list;
            }
            else if (targetType == typeof(long))
            {
                var list = new List<long>();
                foreach (var s in nonNullValues)
                    if (long.TryParse(s, out var n))
                        list.Add(n);
                paramValues = list;
            }
            else if (targetType == typeof(bool))
            {
                var list = new List<bool>();
                foreach (var s in nonNullValues)
                    if (bool.TryParse(s, out var b))
                        list.Add(b);
                paramValues = list;
            }
            else
            {
                // treat as string / fallback
                paramValues = nonNullValues;
            }

            // skip when all values failed to parse
            if (paramValues is IEnumerable en && !en.Cast<object>().Any())
                continue;

            var predicate = $"@0.Contains({field})";
            query = query.Where(predicate, paramValues);
        }

        return query;
    }

    private static Type? GetPropertyType(Type type, string propertyPath)
    {
        var current = type;
        foreach (var part in propertyPath.Split('.'))
        {
            var pi = current.GetProperty(part);
            if (pi == null)
                return null;
            current = pi.PropertyType;
        }

        return current;
    }
}