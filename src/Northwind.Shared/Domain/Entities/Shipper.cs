using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Shipper : IEntity
{
    public int ShipperId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();
}