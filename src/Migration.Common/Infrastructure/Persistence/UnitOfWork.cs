namespace Migration.Common;

public class UnitOfWork<TDbContext>(TDbContext DbContext, IServiceProvider Services)
    : BaseDisposable, IUnitOfWork
    where TDbContext : DbContext
{
    private IDbContextTransaction? _transactionContext;

    private readonly Dictionary<Type, object> _repositories = [];

    public TRepository GetRepository<TRepository,TEntity>()
        where TRepository : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        var key = typeof(TRepository);

        if (_repositories.TryGetValue(key, out var repository))
            return (TRepository)repository;

        var _repository = Services.GetService<TRepository>()
            ?? throw new InvalidCreationException(typeof(TRepository).Name);

        _repositories.Add(key, _repository);

        return _repository;
    }

    public async Task CommitAsync(CancellationToken ct)
    {
        await DbContext.SaveChangesAsync(ct)
            .ConfigureAwait(true);

        DbContext.ChangeTracker.Clear();
    }

    public async Task RollBackAsync(CancellationToken ct) =>
        await DbContext.Database.RollbackTransactionAsync(ct)
            .ConfigureAwait(true);

    public async Task BeginTransactionAsync(CancellationToken ct)
    {
        _transactionContext = await DbContext.Database.BeginTransactionAsync(ct)
            .ConfigureAwait(true);
    }

    public async Task CommitTransactionAsync(CancellationToken ct)
    {
        await _transactionContext.CommitAsync(ct)
            .ConfigureAwait(true);
    }
}
