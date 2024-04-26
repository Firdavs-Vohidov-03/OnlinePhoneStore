namespace Contracts.Responses;

public record class GetAllOrderResponse
{
    public IEnumerable<SingleOrderResponse> Items { get; init; } = Enumerable.Empty<SingleOrderResponse>();
}