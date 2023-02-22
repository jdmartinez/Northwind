using AutoMapper;

namespace Northwind.Basket.Api.DTO;

public class BasketItemDto
{
    //public Guid BasktetId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
