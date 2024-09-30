namespace Domain.Models;

public class CustomerFullStatistic
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CountOfOrders { get; set; }
    public int Sum { get; set; }
}
