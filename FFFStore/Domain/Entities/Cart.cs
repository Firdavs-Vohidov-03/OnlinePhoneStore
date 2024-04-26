namespace Domain.Entities;

public class Cart : BaseEntity
{
    public List<Product> Products { get; set; }
}
