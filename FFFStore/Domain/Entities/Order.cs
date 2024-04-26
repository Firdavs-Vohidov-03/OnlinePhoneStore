using Domain.Enum;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
    public OrderStatus Status { get; set; }
}