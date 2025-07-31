namespace Migration.Domain;

public static class DI
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IBulkJobService, BulkJobService>();

        services.AddScoped<IBatchJobService, BatchJobService>();

        return services;
    }
}
