using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Orders.Application.Interfaces;

public interface IOrdersModule : IApplicationModule
{
    Task<Order> Add(Order order, CancellationToken token = default);

    void Update(Order order);

    Task<Order?> GetByIdAsync(int orderId, CancellationToken token = default);
}
