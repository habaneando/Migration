namespace Migration.UnitTests;

public class BaseUnitTestsFixture : BaseDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public BaseUnitTestsFixture()
    {
        var services = new ServiceCollection();

        ServiceProvider = services.BuildServiceProvider();
    }

    public override void DisposeManagedResources()
    {
        (ServiceProvider as IDisposable)?.Dispose();
    }

    public override void CleanUpUnmanagedResources()
    {
    }
}
