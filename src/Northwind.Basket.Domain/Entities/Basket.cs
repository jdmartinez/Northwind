namespace Northwind.Basket.Domain.Entities;

public class Basket
{
    public Guid Id { get; set; } = new();

    public string CustomerId { get; set; } = default!;

    public ICollection<BasketItem> Items { get; set; } = new HashSet<BasketItem>();

    public Basket(string customerId) => CustomerId = customerId;
}
