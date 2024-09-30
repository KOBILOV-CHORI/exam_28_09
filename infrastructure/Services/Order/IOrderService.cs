namespace infrastructure.Services.Order;

public interface IOrderService
{
    Task<IEnumerable<Domain.Models.Order>> GetOrdersAsync();
    Task<bool> DeleteOrderAsync(Guid id);
    Task<bool> UpdateOrderAsync(Domain.Models.Order order);
    Task<bool> AddOrderAsync(Domain.Models.Order order);
    Task<Domain.Models.Order?> GetOrderByIdAsync(Guid id);
}
