var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Migration_Api>("migration-api");

builder.Build().Run();
