using Ocelot.Administration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services
    .AddOcelot()
    .AddAdministration("/admin", "secret");

builder.Services
    .AddOpenTelemetry()
    .WithTracing(builder =>
    {
        builder.AddAspNetCoreInstrumentation();
        builder.AddRedisInstrumentation();
        builder.AddEntityFrameworkCoreInstrumentation();
        builder.AddConsoleExporter();
    })
    .WithMetrics(metrics =>
    {
        metrics.AddMeter();
        metrics.AddRuntimeInstrumentation();
        metrics.AddAspNetCoreInstrumentation();
        metrics.AddProcessInstrumentation();
        metrics.AddConsoleExporter();
    });

builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();
