namespace Migration.AcceptanceTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly IGetJobLogsService _mockedService;

    public CustomWebApplicationFactory(IGetJobLogsService mockedService)
    {
        _mockedService = mockedService;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(IGetJobLogsService));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddScoped(_ => _mockedService);
        });
    }
}
