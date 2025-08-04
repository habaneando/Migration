namespace Migration.Api;

public sealed class ApiVersion1Group : Group
{
    public ApiVersion1Group()
    {
        Configure("api/v1", ep => { });
    }
}
