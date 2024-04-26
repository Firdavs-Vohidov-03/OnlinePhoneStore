using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class CustomerMapProfile : Profile
{
    public CustomerMapProfile()
    {
        CreateMap<CreateCustomerRequest, Customer>();

        CreateMap<Customer, SingleCustomerResponse>();

        CreateMap<GetAllCustomerRequest, GetAllCustomersResponse>();

        CreateMap<UpdateCustomerRequest, Customer>();
    }
}