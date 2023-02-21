using AutoMapper;

using Northwind.Orders.Api.DTO;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Orders.Api.Mapping.Profile;

public class OrderDtoProfile : AutoMapper.Profile
{
    public OrderDtoProfile()
    {
        CreateMap<OrderDetail, OrderDetailDto>();
        CreateMap<Order, OrderDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.OrderId));
    }
}
