using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Customers.Application.Interfaces;

public interface ICustomersModule : IApplicationModule
{
    Task<Customer> AddAsync(Customer customer, CancellationToken token = default);

    Task<Customer?> GetByIdAsync(string customerId, CancellationToken token = default);

    Task<IReadOnlyList<Customer>?> GetAllAsync(CancellationToken token = default);

    void Update(Customer customer);
}
