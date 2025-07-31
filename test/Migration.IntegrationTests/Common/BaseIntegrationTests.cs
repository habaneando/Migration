namespace Migration.IntegrationTests;

public abstract class BaseIntegrationTests<TFixture> : IClassFixture<TFixture>
    where TFixture : BaseIntegrationTestsFixture, new()
{
    protected readonly TFixture Fixture;

    protected BaseIntegrationTests(TFixture fixture)
    {
        Fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));
    }
}
