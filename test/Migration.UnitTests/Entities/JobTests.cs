namespace Migration.UnitTests;

public class JobTests : BaseUnitTests<BaseUnitTestsFixture>
{
    public JobTests(BaseUnitTestsFixture fixture)
        : base(fixture)
    {
    }

    [Theory]
    [MemberData(nameof(JobData.CreateJob_GivenValidGuid_ShouldBeSuccess), MemberType = typeof(JobData))]
    public void CreateJob_GivenValidGuid_ShouldBeSuccess(Guid guid)
    {
        var id = JobIdFactory.Create(guid);

        var job = new Job(id, null, null);

        job.ShouldNotBeNull();

        job.HasData.ShouldBeFalse();

        job.TotalItems.ShouldBe(0);
    }

    [Theory]
    [MemberData(nameof(JobData.CreateJob_GivenEmptyGuid_ShouldThrowException), MemberType = typeof(JobData))]
    public void CreateJob_GivenEmptyGuid_ShouldThrowException(Guid guid)
    {
        Should.Throw<InvalidJobIdCreationException>(() =>
        {
            var id = JobIdFactory.Create(guid);
        });
    }

    [Theory]
    [MemberData(nameof(JobData.CreateJob_GivenData_ShouldInitializesData), MemberType = typeof(JobData))]
    public void CreateJob_GivenData_ShouldInitializesData(List<Guid> guids)
    {
        var id = JobIdFactory.Create();

        var data = guids.Select(x => new JobItem(JobItemIdFactory.Create(x), "anyValue")).ToList();

        var job = new Job(id, data, null);

        job.ShouldNotBeNull();

        job.HasData.ShouldBeTrue();

        job.TotalItems.ShouldBe(guids.Count);
    }

    [Theory]
    [MemberData(nameof(JobData.CreateJob_GivenMetadata_ShouldInitializesMetadata), MemberType = typeof(JobData))]
    public void CreateJob_GivenMetadata_ShouldInitializesMetadata(JobMetadata jobMetadata)
    {
        var id = JobIdFactory.Create();

        var job = new Job(id, null, jobMetadata);

        job.ShouldNotBeNull();

        job.HasMetadata.ShouldBeTrue();
    }
}
