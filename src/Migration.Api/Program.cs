var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services
    .AddOpenApi()
    .AddDomainServices()
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddApiServices()
    .AddJwtAuthentication()
    .AddThrottling()
    .AddFastEndpoints()
    .AddCors(builder.Configuration)
    .AddComponentHealthChecks()
    .AddAntiforgery()
    .AddResponseCaching()
    .AddDatabase(builder.Configuration);

builder.AddSerilog();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();

    app.MapOpenApi();

    app.AddSwagger();

    app.AddScalar();

    app.AddReDoc();
}

app.UseHttpsRedirection()
   .UseResponseCaching()
   .UseAntiforgeryFE()
   .UseFastEndpoints()
   .UseSerilogRequestLogging()
   .AddCorrelationIdAndClientIdToRequest();

app.Run();
