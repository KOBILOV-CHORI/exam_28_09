namespace Domain.Models;

public class CustomerWithOrderByDate
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Order>? Order { get; set; }
}
