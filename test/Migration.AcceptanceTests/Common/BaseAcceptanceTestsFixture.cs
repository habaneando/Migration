namespace Migration.AcceptanceTests;

public class BaseAcceptanceTestsFixture : BaseDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public BaseAcceptanceTestsFixture()
    {
        var services = new ServiceCollection();
        
        services.AddSingleton<JobId.Factory>();

        services.AddSingleton<JobItemId.Factory>();

        var baseAddress = new Uri("https://localhost:7157");

        services.AddRefitClientService<IJobLogsApi>(baseAddress);

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
