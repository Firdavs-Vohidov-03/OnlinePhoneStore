namespace Domain.Entities;

public class Review : BaseEntity
{
    public string Text { get; set; }
    public int Rating { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}