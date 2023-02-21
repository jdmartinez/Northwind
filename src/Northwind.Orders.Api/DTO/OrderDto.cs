using Northwind.Shared.Domain.Entities;

namespace Northwind.Orders.Api.DTO;

public class OrderDto
{
    public int Id { get; set; }

    public string CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime RequiredDate { get; set; }

    public DateTime ShippedDate { get; set; }

    public int ShipVia { get; set; } = default!;

    public decimal Freight { get; set; } = default!;

    public string ShipName { get; set; } = default!;

    public string ShipAddress { get; set; } = default!;

    public string ShipCity { get; set; } = default!;

    public string ShipRegion { get; set; } = default!;

    public string ShipPostalCode { get; set; } = default!;

    public string ShipCountry { get; set; } = default!;

    public ICollection<OrderDetailDto> OrderDetails { get; set; } = default!;
}
