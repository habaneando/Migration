namespace Migration.AcceptanceTests;

public class GetJobLogsAcceptanceTests : BaseAcceptanceTests<BaseAcceptanceTestsFixture>
{
    public GetJobLogsAcceptanceTests(BaseAcceptanceTestsFixture fixture)
        : base(fixture)
    {
    }

    [Fact]
    public async Task GetJobLogsEndpoint_ShouldReturnLogs_FromRepository()
    {
        ///TODO facing an issue with the dependency injection on refitApi

        //// Arrange
        //var guid = Guid.NewGuid();

        //var expectedLogs = new JobLogs(
        //    guid,
        //    new List<JobLog>
        //    {
        //        new (JobItemIdFactory.Create(), JobLogStatus.Success, "description1"),
        //        new (JobItemIdFactory.Create(), JobLogStatus.Failure, "description2"),
        //        new (JobItemIdFactory.Create(), JobLogStatus.Success, "description3")
        //    });

        //var repoMock = Substitute.For<IJobLogRepository>();

        //var jobId = JobIdFactory.Create(guid);

        //repoMock.GetByJobIdAsync(jobId, Arg.Any<int>(), Arg.Any<int>())
        //    .Returns(Task.FromResult(expectedLogs));

        //var serviceMock = Substitute.For<IGetJobLogsService>();

        //serviceMock.GetLogsByJobIdAsync(guid, Arg.Any<int>(), Arg.Any<int>())
        //    .Returns(repoMock.GetByJobIdAsync(jobId, Arg.Any<int>(), Arg.Any<int>()));

        //var factory = new CustomWebApplicationFactory(serviceMock);

        //var client = factory.CreateClient();

        //var refitApi = RestService.For<IJobLogsApi>(client);

        //// Act
        //var response = await refitApi.GetJobLogsAsync(guid);

        //// Assert
        //response.ShouldNotBeNull();

        //response.JobId.ShouldBe(guid);
    }
}
