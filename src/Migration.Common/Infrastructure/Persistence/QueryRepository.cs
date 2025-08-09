namespace Migration.Common;

public class QueryRepository<TEntity>
    : IQueryRepository<TEntity>
    where TEntity : class, IEntity
{
    private DbContext DbContext { get; init; }

    private DbSet<TEntity> DbSet { get; init; }

    public QueryRepository(DbContext dbContext)
    {
        DbContext = dbContext;

        DbSet = DbContext.Set<TEntity>();
    }

    public async virtual Task<TEntity> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = (orderBy is null)
            ? await query.FirstOrDefaultAsync()
                .ConfigureAwait(false)
            : await orderBy(query).FirstOrDefaultAsync()
                .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<TResult> GetFirstOrDefaultAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
        where TResult : class
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = (orderBy is null)
            ? await query
                .Select(selector)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false)
            : await orderBy(query)
                .Select(selector)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<TEntity> GetSingleOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = await query.SingleOrDefaultAsync()
            .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<TResult> GetSingleOrDefaultAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? filter = null,
        string includeProperties = "")
        where TResult : class
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = await query
            .Select(selector)
            .SingleOrDefaultAsync()
            .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = DbSet;

        query = query.TryWhere(filter);

        var queryToExecute = await query.CountAsync()
            .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = DbSet;

        query = query.TryWhere(filter);

        var queryToExecute = await query.AnyAsync()
            .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = (orderBy is null)
            ? await query.ToListAsync()
                .ConfigureAwait(false)
            : await orderBy(query)
                .ToListAsync()
                .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<IEnumerable<TResult>> GetAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TResult>, IOrderedQueryable<TResult>>? orderBy = null,
        string includeProperties = "")
        where TResult : class
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = (orderBy is null)
            ? await query
                .Select(selector)
                .ToListAsync()
                .ConfigureAwait(false)
            : await orderBy(query.Select(selector))
                .ToListAsync()
                .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<IPagedList<TEntity>> GetAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = (orderBy is null)
            ? await query.ToPagedListAsync(pageNumber, pageSize)
                .ConfigureAwait(false)
            : await orderBy(query)
                .ToPagedListAsync(pageNumber, pageSize)
                .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<IPagedList<TResult>> GetAsync<TResult>(
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TResult>, IOrderedQueryable<TResult>>? orderBy = null,
        string includeProperties = "")
        where TResult : class
    {
        IQueryable<TEntity> query = DbSet;

        query = query
            .TryWhere(filter)
            .TryInclude(includeProperties);

        var queryToExecute = (orderBy is null)
            ? await query
                .Select(selector)
                .ToPagedListAsync(pageNumber, pageSize)
                .ConfigureAwait(false)
            : await orderBy(query.Select(selector))
                .ToPagedListAsync(pageNumber, pageSize)
                .ConfigureAwait(false);

        return queryToExecute;
    }

    public async virtual Task<TEntity> GetByIdAsync(object id) =>
        await DbSet.FindAsync(id)
            .ConfigureAwait(false);
}
