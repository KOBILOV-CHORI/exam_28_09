using Domain.Models;

namespace infrastructure.Services.Requests;

public interface IRequestService
{
    Task<IEnumerable<CustomerWithOrderByDate>> GetCustomersByDateAsync(DateTime StartDate, DateTime EndDate);
    Task<IEnumerable<Domain.Models.Product>> GetProductsAsync();
    Task<IEnumerable<CustomerFullStatistic>> GetCustomerStatisticsAsync();
    Task<IEnumerable<OrderFullStatistic>> GetOrderStatisticsAsync();
    Task<IEnumerable<Domain.Models.Order>> GetOrdersByStatusAndDateAsync(string status, DateTime startDate, DateTime endDate);
    Task<Domain.Models.Product?> GetPopularProductAsync();
    Task<SalesStatistic?> GetSalesStatisticsAsync(int month, int year);
    Task<IEnumerable<Domain.Models.Customer>> GetInactiveCustomersAsync();
    Task<IEnumerable<Domain.Models.Order>> GetOrdersByProductIdAsync(Guid productId);
    Task<IEnumerable<ProductSummary>> GetProductsSummaryAsync();
}
