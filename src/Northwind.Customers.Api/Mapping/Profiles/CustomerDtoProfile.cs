using AutoMapper;

using Northwind.Customers.Api.DTO;
using Northwind.Shared.Domain.Entities;
using Northwind.Shared.Infrastructure.DTO;

namespace Northwind.Customers.Api.Mapping.Profiles;

public class CustomerDtoProfile : Profile
{
    public CustomerDtoProfile() 
    {        
        CreateMap<Customer, CustomerDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dto => dto.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
            .ForMember(dto => dto.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dto => dto.ContactTitle, opt => opt.MapFrom(src => src.ContactTitle))
            .ForMember(dto => dto.Address, opt => opt.MapFrom(src => new AddressDTO
            {
                Street = src.Address,
                City = src.City,
                Region = src.Region,
                Country = src.Country,
                PostalCode = src.PostalCode
            }))
            .ForMember(dto => dto.Phone, opt => opt.MapFrom(src => src.Phone));
    }
}
