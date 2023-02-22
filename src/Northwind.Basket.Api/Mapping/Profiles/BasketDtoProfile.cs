using AutoMapper;

using Northwind.Basket.Api.DTO;

namespace Northwind.Basket.Api.Mapping.Profiles;

public class BasketDtoProfile : Profile
{
    public BasketDtoProfile()
    {
        CreateMap<string, Guid>().ConvertUsing(s => Guid.Parse(s));

        CreateMap<Domain.Entities.Basket, BasketDto>()
            .ReverseMap();
        CreateMap<Domain.Entities.BasketItem, BasketItemDto>()
            .ReverseMap();
    }
}
