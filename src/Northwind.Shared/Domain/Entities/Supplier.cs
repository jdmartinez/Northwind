using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Supplier : IEntity
{
    public int SupplierId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactTitle { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string HomePage { get; set; } = null!;

    public ICollection<Product> Products { get; private set; } = new HashSet<Product>();
}