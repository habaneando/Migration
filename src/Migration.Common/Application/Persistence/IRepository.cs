namespace Migration.Common;

public interface IRepository<TEntity>
    where TEntity : class, ITypedEntity
{
}
