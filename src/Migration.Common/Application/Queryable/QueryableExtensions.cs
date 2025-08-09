namespace Migration.Common;

public static class QueryableExtensions
{
    private static readonly int _defaultPageNumber = 1;

    private static readonly int _defaultPageSize = 10;

    public static async Task<IPagedList<TEntity>> ToPagedListAsync<TEntity>(
        this IQueryable<TEntity> query,
        int pageNumber,
        int pageSize,
        CancellationToken token = default)
    {
        pageNumber = pageNumber < _defaultPageNumber
            ? _defaultPageNumber
            : pageNumber;

        pageSize = pageSize < _defaultPageSize
            ? _defaultPageSize
            : pageSize;

        var count = await query.CountAsync(token)
            .ConfigureAwait(false);

        if (count <= 0)  
            return new PagedList<TEntity>([], 0, 0, 0);

        if ((pageNumber > 1) && 
            (pageNumber * pageSize > count))
            throw new PaginationException(pageNumber, pageSize, count);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);

        var pagedList = new PagedList<TEntity>(items, count, pageNumber, pageSize);

        return pagedList;
    }

    public static IQueryable<TEntity> TryInclude<TEntity>(
        this IQueryable<TEntity> query,
        string includeProperties)
        where TEntity : class, IEntity
    {
        if (string.IsNullOrEmpty(includeProperties))
            return query;

        includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries)
        .ToList()
        .ForEach(includeProperty =>
            query = EntityFrameworkQueryableExtensions.Include(query, includeProperty));

        return query;
    }

    public static IQueryable<TEntity> TryWhere<TEntity>(
        this IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>> filter)
        where TEntity : class, IEntity
    {
        if (filter is null)
            return query;
        
        query = query.Where(filter);

        return query;
    }
}
