namespace Migration.AcceptanceTests;

public abstract class BaseAcceptanceTests<TFixture> : IClassFixture<TFixture>
    where TFixture : BaseAcceptanceTestsFixture, new()
{
    protected readonly TFixture Fixture;

    public JobId.Factory JobIdFactory { get; init; }

    public JobItemId.Factory JobItemIdFactory { get; init; }

    protected BaseAcceptanceTests(TFixture fixture)
    {
        Fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));

        JobIdFactory = fixture.ServiceProvider.GetService<JobId.Factory>()
            ?? throw new InvalidServiceRegistrationException("JobId.Factory");

        JobItemIdFactory = fixture.ServiceProvider.GetService<JobItemId.Factory>()
            ?? throw new InvalidServiceRegistrationException("JobItemId.Factory");
    }
}
