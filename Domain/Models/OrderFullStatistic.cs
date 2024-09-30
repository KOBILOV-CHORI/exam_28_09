namespace Domain.Models;

public class OrderFullStatistic
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer? Customer { get; set; }
    public Product? Product { get; set; }
}
