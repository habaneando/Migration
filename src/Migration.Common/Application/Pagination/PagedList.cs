namespace Migration.Common;

public class PagedList<T> : IPagedList<T>
{
    public IList<T> Items { get; init; }

    public int Count { get; init; }

    public int PageNumber { get; init; }

    public int PageSize { get; init; }

    public int TotalPages =>
        (int)Math.Ceiling(Count / (double)PageSize);

    public bool IsFirstPage => 
        PageNumber == 1;

    public bool IsLastPage => 
        PageNumber == TotalPages;

    public T this[int index] => 
        Items[index];

    public IEnumerator<T> GetEnumerator() => 
        Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => 
        Items.GetEnumerator();

    public PagedList(
        IEnumerable<T> items,
        int count,
        int pageNumber,
        int pageSize)
    {
        Items = items as IList<T> ?? [.. items];

        Count = count;

        PageNumber = pageNumber;

        PageSize = pageSize;
    }
}
