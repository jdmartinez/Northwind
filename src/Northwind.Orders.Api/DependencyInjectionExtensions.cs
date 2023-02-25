using Microsoft.EntityFrameworkCore;

using Northwind.Orders.Application.Interfaces;
using Northwind.Orders.Application.Modules;
using Northwind.Orders.Application.Repositories;
using Northwind.Orders.Infrastructure.Repositories;
using Northwind.Shared.Application.Events.Handlers;
using Northwind.Shared.Application.Events;
using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Infrastructure.Persistence;

namespace Northwind.Orders.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, NorthwindContext>();
        services.AddDbContext<NorthwindContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Database")),
            ServiceLifetime.Transient);

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrdersModule, OrdersModule>();

        services.AddTransient<OrderAcceptedEventHandler, OrderAcceptedEventHandler>();

        return services;
    }
}
