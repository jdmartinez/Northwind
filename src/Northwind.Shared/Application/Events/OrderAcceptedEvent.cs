namespace Northwind.Shared.Application.Events;

public record class OrderAcceptedEvent : IntegrationEvent
{
    public record class OrderAcceptedItem
    {
        public int ProductId { get; init; }

        public int Quantity { get; init; }
    }

    public string CustomerId { get; init; } = default!;

    public List<OrderAcceptedItem> Items { get; init; } = new();
    
}
