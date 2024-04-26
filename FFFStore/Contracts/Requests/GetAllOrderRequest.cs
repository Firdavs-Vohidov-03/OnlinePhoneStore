using Domain.Entities;

namespace Contracts.Requests;

public record class GetAllOrderRequest
{
    public IEnumerable<Order> Items { get; init; } = Enumerable.Empty<Order>();

}