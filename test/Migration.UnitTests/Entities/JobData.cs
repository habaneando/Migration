namespace Migration.UnitTests;

public class JobData
{
    public static IEnumerable<object[]> CreateJob_GivenValidGuid_ShouldBeSuccess =>
       new List<object[]>
       {
            new object[]
            {
                Guid.NewGuid(),
                JobType.Bulk
            },
       };

    public static IEnumerable<object[]> CreateJob_GivenEmptyGuid_ShouldThrowException =>
       new List<object[]>
       {
            new object[]
            {
                Guid.Empty
            },
       };

    public static IEnumerable<object[]> CreateJob_GivenData_ShouldInitializesData =>
       new List<object[]>
       {
            new object[]
            {
                new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid()
                },
                JobType.Batch
            },
       };

    public static IEnumerable<object[]> CreateJob_GivenMetadata_ShouldInitializesMetadata =>
       new List<object[]>
       {
            new object[]
            {
                JobType.Bulk,
                new JobMetadata
                {
                    Description = "Test job",
                    Source = "Source system",
                    Target = "Target system",
                    Priority = 1,
                    Tags = new List<string> { "tag1", "tag2" }
                }
            },
       };
}
