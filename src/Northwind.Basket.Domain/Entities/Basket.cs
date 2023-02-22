namespace Northwind.Basket.Domain.Entities;

public class Basket
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string CustomerId { get; set; } = default!;

    public List<BasketItem> Items { get; set; } = new();

    public Basket(string customerId) => CustomerId = customerId;

    public void AddItem(BasketItem basketItem) => Items.Add(basketItem);

    public void AddItem(int productId, int quantity = 1)
    {
        BasketItem item;

        if (!Items.Any(i => i.ProductId == productId))
        {
            item = new BasketItem(Id, productId, quantity);
        }

        item = Items.First(i => i.ProductId == productId);
        item.AddQuantity(quantity);
    }
}
