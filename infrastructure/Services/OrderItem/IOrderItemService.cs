namespace infrastructure.Services.OrderItem;

public interface IOrderItemService
{
    Task<IEnumerable<Domain.Models.OrderItem>> GetOrderItemsAsync();
    Task<bool> DeleteOrderItemAsync(Guid id);
    Task<bool> UpdateOrderItemAsync(Domain.Models.OrderItem orderItem);
    Task<bool> AddOrderItemAsync(Domain.Models.OrderItem orderItem);
    Task<Domain.Models.OrderItem?> GetOrderItemByIdAsync(Guid id);
}
