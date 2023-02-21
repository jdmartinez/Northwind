using Northwind.Customers.Application.Interfaces;
using Northwind.Customers.Application.Repositories;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Customers.Application.Modules;

public class CustomersModule : ICustomersModule
{
    private readonly ICustomerRepository _repository;

    public CustomersModule(ICustomerRepository repository) => _repository = repository;

    public async Task<Customer> AddAsync(Customer customer, CancellationToken token = default) => await _repository.AddAsync(customer, token);

    public async Task<IReadOnlyList<Customer>?> GetAllAsync(CancellationToken token = default)
        => await _repository.GetAllAsync(token);

    public async Task<Customer?> GetByIdAsync(string customerId, CancellationToken token = default)
        => await _repository.GetAsync(customerId, token);

    public void Update(Customer customer) => _repository.Update(customer);
    
}
