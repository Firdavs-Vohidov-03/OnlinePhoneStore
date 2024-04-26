using Domain.Entities;

namespace Contracts.Requests;

public record class GetAllCustomerRequest
{
    public IEnumerable<Customer> Items { get; init; } = Enumerable.Empty<Customer>();

}