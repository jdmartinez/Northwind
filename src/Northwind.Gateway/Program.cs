using Ocelot.Administration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
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
    .WithTracing(tracing =>
    {
        tracing.ConfigureResource(resource =>
        {
            resource.AddService(
                builder.Environment.ApplicationName,
                builder.Environment.EnvironmentName,
                builder.Configuration["OpenTelemetry:ApplicationVersion"],
                false,
                Environment.MachineName);
        })
        .AddHttpClientInstrumentation(opt => opt.RecordException = true)
        .AddAspNetCoreInstrumentation(opt => opt.RecordException = true)
        .AddRedisInstrumentation()
        .AddSqlClientInstrumentation(opt =>
        {
            opt.RecordException = true;
            opt.SetDbStatementForText = true;
        })
        .AddEntityFrameworkCoreInstrumentation(opt => opt.SetDbStatementForText = true)
        .AddOtlpExporter(opt =>
        {
            opt.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
            opt.Endpoint = new Uri(builder.Configuration["OpenTelemetry:Exporter:Otlp:Endpoint"]!);
        })
        .AddConsoleExporter();

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
