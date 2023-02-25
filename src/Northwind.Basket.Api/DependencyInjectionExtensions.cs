using Microsoft.EntityFrameworkCore;

using Northwind.Basket.Application.Interfaces;
using Northwind.Basket.Application.Modules;
using Northwind.Basket.Application.Repositories;
using Northwind.Basket.Infrastructure.Persistance;
using Northwind.Basket.Infrastructure.Repositories;
using Northwind.Shared.Application.Events;
using Northwind.Shared.Application.Events.Handlers;
using Northwind.Shared.Application.Interfaces;

namespace Northwind.Basket.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<BasketDbContext>(
            options => options.UseInMemoryDatabase("Baskets"),
            ServiceLifetime.Transient);

        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IBasketModule, BasketModule>();        

        return services;
    }
}
