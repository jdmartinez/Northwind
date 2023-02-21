using AutoMapper;
using Northwind.Products.Api.DTO;

using Northwind.Shared.Domain.Entities;

namespace Northwind.Products.Api.Mapping.Profiles;

public class ProductDtoProfile : Profile
{
    public ProductDtoProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dto => dto.UnitPrice, 
                opt => opt.MapFrom(src => src.UnitPrice == null ? decimal.Zero : Math.Round((decimal)src.UnitPrice, 2, MidpointRounding.AwayFromZero)))
            .ForMember(dto => dto.AvailableStock, opt => opt.MapFrom(src => src.UnitsInStock))
            .ForMember(dto => dto.ReservedStock, opt => opt.MapFrom(src => src.UnitsOnOrder));
    }
}
