namespace Migration.Common;

public interface ICrudRepository<TEntity>
    : IRepository<TEntity>
    where TEntity : IEntity
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

    Task AddAsync(TEntity entity);

    Task DeleteAsync(object id);

    Task DeleteAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);
}
