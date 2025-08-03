using Migration.Domain;

namespace Migration.UnitTests;

public class BaseUnitTestsFixture : BaseDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public BaseUnitTestsFixture()
    {
        var services = new ServiceCollection();

        services.AddSingleton<JobId.Factory>();

        services.AddSingleton<JobItemId.Factory>();

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
