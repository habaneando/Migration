namespace Migration.Common;

public interface ICommandRepository<TEntity>
    : IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task AddAsync(TEntity entity);

    Task DeleteAsync(object id);

    Task DeleteAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);
}
