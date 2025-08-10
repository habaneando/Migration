namespace Migration.Common;

public class CommandEfRepository<TEntity> : BaseEfRepository<TEntity>, ICommandRepository<TEntity>
    where TEntity : class, ITypedEntity
{
    public CommandEfRepository(DbContext dbContext)
        : base(dbContext){}

    public async virtual Task AddAsync(TEntity entity) =>
        await DbSet.AddAsync(entity)
            .ConfigureAwait(false);

    public async virtual Task DeleteAsync(object id)
    {
        var entity = await DbSet.FindAsync(id)
            .ConfigureAwait(false);

        await DeleteAsync(entity)
            .ConfigureAwait(false);
    }

    public async virtual Task DeleteAsync(TEntity entity)
    {
        if (DbContext.Entry(entity).State == EntityState.Detached)
            DbSet.Attach(entity);

        await Task.Run(() => DbSet.Remove(entity))
            .ConfigureAwait(false);
    }

    public async virtual Task UpdateAsync(TEntity entity) =>
        await Task.Run(() =>
        {
            DbSet.Update(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        })
        .ConfigureAwait(false);
}
