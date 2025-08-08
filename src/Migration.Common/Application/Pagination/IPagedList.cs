namespace Migration.Common;

public interface IPagedList<T> : IReadOnlyList<T>
{
    IList<T> Items { get; init; }

    int PageNumber { get; init; }

    int PageSize { get; init; }

    int TotalPages { get; }

    bool IsFirstPage { get; }

    bool IsLastPage { get; }
}
