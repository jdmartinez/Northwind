namespace Northwind.Basket.Domain.Entities;

public class BasketItem
{
    public Guid Id { get; set; } = new();

    public Guid BasketId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}