using Domain.Entities;

namespace Contracts.Responses;

public record class SingleCustomerResponse
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
}