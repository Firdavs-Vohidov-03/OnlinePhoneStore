using Domain.Entities;

namespace Contracts.Requests;

public record class UpdateCustomerRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}