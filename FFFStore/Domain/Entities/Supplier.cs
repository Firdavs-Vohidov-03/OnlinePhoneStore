namespace Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public List<Product> Products { get; set; }
}