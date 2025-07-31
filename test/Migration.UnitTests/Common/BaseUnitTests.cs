namespace Migration.UnitTests;

public abstract class BaseUnitTests<TFixture> : IClassFixture<TFixture>
    where TFixture : BaseUnitTestsFixture, new()
{
    protected readonly TFixture Fixture;

    protected BaseUnitTests(TFixture fixture)
    {
        Fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));
    }
}
