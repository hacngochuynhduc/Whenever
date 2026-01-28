namespace Whenever.Infrastruture.Collection;

public class ManualPagedList<T> : IPagedList<T>
{
    public ManualPagedList(IList<T> items, int pageIndex, int pageSize, int totalCount)
    {
        Items = items;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public IList<T> Items { get; }
}