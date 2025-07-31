namespace Migration.Api;

public class GetJobLogsRequest
{
    public string JobId { get; set; }

    public int? Page { get; set; }

    public int? PageSize { get; set; }
}
