namespace Contracts.Responses;

public record class GetAllCustomersResponse
{
    public IEnumerable<SingleCustomerResponse> Items { get; init; } = Enumerable.Empty<SingleCustomerResponse>();
}