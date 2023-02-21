using Northwind.Shared.Infrastructure.DTO;

namespace Northwind.Customers.Api.DTO;

public class CustomerDto
{
    public string Id { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactTitle { get; set; } = null!;

    public AddressDTO Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
    
}
