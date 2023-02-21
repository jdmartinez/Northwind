using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Orders.Application.Repositories;

public interface IOrderRepository : IRepository<Order>
{

}