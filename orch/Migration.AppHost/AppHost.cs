var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Migration_Api>("migration-api")
    .WithSwaggerUI()
    .WithScalar()
    .WithReDoc();

builder.Build().Run();
