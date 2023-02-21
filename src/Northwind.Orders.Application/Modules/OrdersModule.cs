using Northwind.Orders.Application.Interfaces;
using Northwind.Orders.Application.Repositories;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Orders.Application.Modules;

public class OrdersModule : IOrdersModule
{
    private readonly IOrderRepository _respository;

    public OrdersModule(IOrderRepository repository) => _respository = repository;

    public async Task<Order> Add(Order order, CancellationToken token = default) => await _respository.AddAsync(order, token);

    public async Task<Order?> GetByIdAsync(int orderId, CancellationToken token = default)
        => await _respository.GetAsync(orderId, token);

    public void Update(Order order) => _respository.Update(order);
    
}
