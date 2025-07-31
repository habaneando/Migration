namespace Migration.Common;

public abstract class BaseDisposable : IDisposable
{
    private bool _disposed = false;

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

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose managed resources like objects that implement IDisposable,
    /// event subscriptions, collections, timers, cancellation tokens
    /// </summary>
    public abstract void DisposeManagedResources();

    /// <summary>
    /// Clean up unmanaged resources like file handles, database connections, network sockets, Win32 handles,
    /// allocated memory, and other system resources not managed by the garbage collector
    /// </summary>
    public abstract void CleanUpUnmanagedResources();
}
