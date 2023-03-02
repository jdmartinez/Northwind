using Northwind.Customers.Application.Repositories;
using Northwind.Shared.Domain.Entities;
using Northwind.Shared.Infrastructure.Caching;
using Northwind.Shared.Infrastructure.Persistence;

namespace Northwind.Customers.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(NorthwindContext context) : base(context)
    { }    
}
