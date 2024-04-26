using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;

namespace Application.Common.Mapping;

public class ProductMapProfile : Profile
{
    public ProductMapProfile()
    {
        CreateMap<CreateProductRequest, Product>();

        CreateMap<Product, SingleProductResponse>();

        CreateMap<GetAllProductRequest, GetAllProductResponse>();

        CreateMap<UpdateProductRequest, Product>();
    }
}