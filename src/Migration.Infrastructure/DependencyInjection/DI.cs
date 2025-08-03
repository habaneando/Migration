namespace Migration.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, MockJobRepository>();

        services.AddScoped<IJobLogRepository, MockJobLogRepository>();

        services.AddScoped<IUnitOfWork, MockUnitOfWork>();

        services.AddScoped<IDataProcessingService, DataProcessingService>();

        services.AddSingleton<IJobServiceProvider>(x =>
        {
            var jobServiceProvider = new JobServiceProvider();

            var serviceProvider = services.BuildServiceProvider();

            var bulkService = serviceProvider.GetRequiredService<IBulkJobService>();

            if (bulkService is not null)
                jobServiceProvider.Add("bulk", bulkService);

            var batchService = serviceProvider.GetRequiredService<IBatchJobService>();

            if (batchService is not null)
                jobServiceProvider.Add("batch", batchService);

            return jobServiceProvider;
        } );

        return services;
    }
}
