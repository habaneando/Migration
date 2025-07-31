namespace Migration.UnitTests;

public class BaseUnitTestsFixture : IDisposable
{
    private bool _disposed = false;

    public IServiceProvider ServiceProvider { get; }

    public BaseUnitTestsFixture()
    {
        var services = new ServiceCollection();

        ServiceProvider = services.BuildServiceProvider();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                DisposeManagedResources();
            }

            CleanUpUnmanagedResources();

            _disposed = true;
        }
    }

    /// <summary>
    /// Objects that implement IDisposable, event subscriptions,
    /// collections, timers, cancellation tokens
    /// </summary>
    private void DisposeManagedResources()
    {
        (ServiceProvider as IDisposable)?.Dispose();
    }

    /// <summary>
    /// File handles, database connections, network sockets, Win32 handles, allocated memory,
    /// and other system resources not managed by the garbage collector
    /// </summary>
    private void CleanUpUnmanagedResources()
    {
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
