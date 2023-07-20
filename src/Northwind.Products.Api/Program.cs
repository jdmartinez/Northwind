using System.Reflection;

using Newtonsoft.Json.Converters;

using Northwind.Products.Api;
using Northwind.Products.Api.Grpc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
    .AddSwaggerGenNewtonsoftSupport();

builder.Services.AddGrpc();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

    endpoints.MapGet("/_proto/", async ctx =>
    {
        ctx.Response.ContentType = "text/plain";
        using var fs = new FileStream(Path.Combine(app.Environment.ContentRootPath, "Proto", "catalog.proto"), FileMode.Open, FileAccess.Read);
        using var sr = new StreamReader(fs);
        while (!sr.EndOfStream)
        {
            var line = await sr.ReadLineAsync();
            if (line != "/* >>" || line != "<< */")
            {
                await ctx.Response.WriteAsync(line);
            }
        }
    });

    endpoints.MapGrpcService<ProductService>();
});

app.MapControllers();

app.Run();
