using Northwind.Shared.Domain.Interfaces;
using Northwind.Shared.Domain.ValueObjects;

namespace Northwind.Shared.Domain.Entities;

public class Order : IEntity
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; } = default!;

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; } 

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; } = default!;

    public decimal? Freight { get; set; } = default!;

    public string? ShipName { get; set; } = default!;

    public string? ShipAddress { get; set; } = default!;

    public string? ShipCity { get; set; } = default!;

    public string? ShipRegion { get; set; } = default!;

    public string? ShipPostalCode { get; set; } = default!;

    public string? ShipCountry { get; set; } = default!;

    public Customer Customer { get; set; } = default!;

    public Employee Employee { get; set; } = default!;

    public Shipper Shipper { get; set; } = default!;

    public ICollection<OrderDetail> OrderDetails { get; private set; } = new HashSet<OrderDetail>();

}