namespace Contracts.Responses;

public record class GetAllProductResponse
{
    public IEnumerable<SingleProductResponse> Items { get; init; } = Enumerable.Empty<SingleProductResponse>();
}