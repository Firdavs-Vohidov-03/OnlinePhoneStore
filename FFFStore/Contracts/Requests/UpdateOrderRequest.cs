using Domain.Entities;
using Domain.Enum;
using System.Collections.Generic;

namespace Contracts.Requests;

public record class UpdateOrderRequest
{
    public DateTime OrderDate { get; set; }
    public Guid CustomerId { get; set; }
    public List Products { get; set; }
    public OrderStatus Status { get; set; }
}