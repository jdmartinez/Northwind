using Microsoft.EntityFrameworkCore;

using Northwind.Orders.Application.Repositories;
using Northwind.Shared.Domain.Entities;
using Northwind.Shared.Infrastructure.Persistence;

namespace Northwind.Orders.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(NorthwindContext context) : base(context) 
    { }

    public override async Task<Order?> GetAsync<TId>(TId id, CancellationToken token = default)
    {
        var order = await base.GetAsync(id, token);

        order ??= _context.Set<Order>().Local.FirstOrDefault(o => o.OrderId.Equals(id));

        if (order != null)
        {
            await _context.Entry(order)
                .Reference(o => o.Customer).LoadAsync(token);
            await _context.Entry(order)
                .Collection(o => o.OrderDetails)
                .LoadAsync(token);
        }

        return order;
    }    
}
