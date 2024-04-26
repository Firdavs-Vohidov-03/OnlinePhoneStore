using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class OrderMapProfile : Profile
{
    public OrderMapProfile()
    {
        CreateMap<CreateOrderRequest, Order>();

        CreateMap<Order, SingleOrderResponse>();

        CreateMap<GetAllOrderRequest, GetAllOrderResponse>();

        CreateMap<UpdateOrderRequest, Order>();
    }
}