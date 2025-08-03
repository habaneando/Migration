namespace Migration.UnitTests;

public class JobIdTests : BaseUnitTests<BaseUnitTestsFixture>
{
    public JobIdTests(BaseUnitTestsFixture fixture)
        : base(fixture)
    {
    }

    [Fact]
    public void CreateJobId_WhenCalled_ReturnsJobIdWithNonEmptyGuid()
    {
        var jobId = JobIdFactory.Create();

        jobId.ShouldNotBeNull();

        jobId.Id.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public void CreateJobId_MultipleCalls_ReturnsDifferentGuids()
    {
        var jobId = JobIdFactory.Create();

        var otherJobId = JobIdFactory.Create();

        jobId.ShouldNotBeNull();

        otherJobId.ShouldNotBeNull();

        jobId.Id.ShouldNotBe(otherJobId.Id);
    }
}
