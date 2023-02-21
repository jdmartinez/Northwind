namespace Northwind.Basket.Api.DTO;

public class BasketDto
{
    public Guid Id { get; set; }

    public string CustomerId { get; set; } = default!;

    public ICollection<BasketItemDto> Items { get; set; } = default!;

    public BasketDto(string customerId) => CustomerId = customerId;    

}