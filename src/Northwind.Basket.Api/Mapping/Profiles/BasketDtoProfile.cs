using AutoMapper;

using Northwind.Basket.Api.DTO;

namespace Northwind.Basket.Api.Mapping.Profiles;

public class BasketDtoProfile : Profile
{
    public BasketDtoProfile()
    {
        CreateMap<Domain.Entities.Basket, BasketDto>();
        CreateMap<Domain.Entities.BasketItem, BasketItemDto>()
            .ForMember(dto => dto.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dto => dto.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}
