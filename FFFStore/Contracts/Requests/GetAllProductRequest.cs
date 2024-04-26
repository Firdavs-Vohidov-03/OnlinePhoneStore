using Domain.Entities;

namespace Contracts.Requests;

public record class GetAllProductRequest
{
    public IEnumerable<Product> Items { get; init; } = Enumerable.Empty<Product>();

}