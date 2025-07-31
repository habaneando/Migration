namespace Migration.AcceptanceTests;

public abstract class BaseAcceptanceTests<TFixture> : IClassFixture<TFixture>
    where TFixture : BaseAcceptanceTestsFixture, new()
{
    protected readonly TFixture Fixture;

    protected BaseAcceptanceTests(TFixture fixture)
    {
        Fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));
    }
}
