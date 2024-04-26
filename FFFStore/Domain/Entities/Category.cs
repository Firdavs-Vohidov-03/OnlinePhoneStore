using Domain.Enum;

namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; }
    
    public CategoryType Status { get; set; }
}