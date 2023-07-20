using Northwind.Shared.Domain.Entities;

namespace Northwind.Orders.Api.DTO;

public class OrderDetailDto
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = default!;

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

}