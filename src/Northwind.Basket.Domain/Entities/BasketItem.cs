namespace Northwind.Basket.Domain.Entities;

public class BasketItem
{
    public Guid BasketId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public BasketItem() 
    { }

    public BasketItem(Guid basketId) => BasketId = basketId;

    public BasketItem(Guid basketId, int productId, int quantity) : this(basketId)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public void AddQuantity(int quantity)
    {
        if (!(quantity > 0 && quantity <= int.MaxValue)) throw new ArgumentOutOfRangeException(nameof(quantity));

        Quantity += quantity;
    }
}