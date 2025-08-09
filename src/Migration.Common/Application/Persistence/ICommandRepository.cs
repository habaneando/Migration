namespace Migration.Common;

public interface ICommandRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, ITypedEntity
{
    Task AddAsync(TEntity entity);

    Task DeleteAsync(object id);

    Task DeleteAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);
}
