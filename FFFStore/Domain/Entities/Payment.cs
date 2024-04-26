using Domain.Enum;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    
    public PaymentStatus Status { get; set; }
}