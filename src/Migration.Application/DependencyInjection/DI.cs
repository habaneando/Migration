namespace Migration.Application;

public static class DI
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBulkJobService, BulkJobService>();

        services.AddScoped<IBatchJobService, BatchJobService>();

        services.AddSingleton<IJobTypeValidator, JobTypeValidator>();

        services.AddScoped<IJobProcessingService, JobProcessingService>();

        services.AddScoped<IGetJobStatusService, GetJobStatusService>();

        services.AddScoped<IGetJobLogsService, GetJobLogsService>();

        return services;
    }
}
