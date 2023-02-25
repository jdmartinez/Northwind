using System.Reflection;

using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;

using Northwind.Shared.Infrastructure.EventBus.Consumers;
using Northwind.Shared.Infrastructure.EventBus.RabbitMq;

using Northwind.Shared.Infrastructure.EventBus.Settings;

using Serilog;

namespace Northwind.Orders.Api;

public class Program
{
    public static void Main(string[] args)
    {        
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

        // Add services to the container.
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen()
            .AddSwaggerGenNewtonsoftSupport();

        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // RabbitMq 
        builder.Services.Configure<EventBusSettings>(builder.Configuration.GetSection("Rabbit"));
        builder.Services.AddSingleton(f => f.GetRequiredService<IOptions<EventBusSettings>>().Value);        
        builder.Services.AddHostedService<OrderAcceptedService>();

        var app = builder.Build();

        app.UseSerilogRequestLogging();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            endpoints.MapControllers();
        });

        app.MapControllers();                

        app.Run();
    }
}