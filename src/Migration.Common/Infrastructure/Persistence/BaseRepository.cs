namespace Migration.Common;

public class BaseRepository<TEntity>
    : IRepository<TEntity>
    where TEntity : class, ITypedEntity
{
    protected DbContext DbContext { get; init; }

    protected DbSet<TEntity> DbSet { get; init; }

    public BaseRepository(DbContext dbContext)
    {
        DbContext = dbContext;

        DbSet = DbContext.Set<TEntity>();
    }
}
