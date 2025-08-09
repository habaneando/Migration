namespace Migration.Common;

public interface IQueryRepository<TEntity>
    : IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<TEntity> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    Task<TEntity> GetSingleOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        string includeProperties = "");

    Task<int> GetCountAsync(
        Expression<Func<TEntity, bool>>? filter = null);

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? filter = null);

    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    Task<TEntity> GetByIdAsync(object id);
}
