namespace Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
