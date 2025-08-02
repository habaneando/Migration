var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services
    .AddOpenApi()
    .AddDomainServices()
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddApiServices()
    .AddThrottling()
    .AddFastEndpoints()
    .AddAntiforgery()
    .AddResponseCaching();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();

    app.MapOpenApi();

    app.AddSwagger();

    app.AddScalar();

    app.AddReDoc();
}

app.UseResponseCaching()
   .UseAntiforgeryFE()
   .UseFastEndpoints();

app.UseHttpsRedirection();

app.Run();
