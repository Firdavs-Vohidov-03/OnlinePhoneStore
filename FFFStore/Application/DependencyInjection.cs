using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IBaseService<Customer>, CustomerService>();
        services.AddTransient<IBaseService<Product>, ProductService>();
        services.AddTransient<IBaseService<Order>, OrderService>();
        return services;
    }
}