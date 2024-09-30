using Dapper;
using Domain.Models;
using Npgsql;

namespace infrastructure.Services.Requests;

public class RequestService : IRequestService
{
    public async Task<IEnumerable<CustomerWithOrderByDate>> GetCustomersByDateAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                var customers = await connection.QueryAsync<Domain.Models.Customer>(SqlCommands.GetAllCustomers);
                List<CustomerWithOrderByDate> rescustomers = new List<CustomerWithOrderByDate>();
                foreach (var customer in customers)
                {
                    var order = await connection.QueryAsync<Domain.Models.Order>(SqlCommands.GetOrderByCustomerId, new { CustomerId = customer.Id, StartDate = startDate, EndDate = endDate });
                    rescustomers.Add(new CustomerWithOrderByDate() { CreatedAt = customer.CreatedAt, Email = customer.Email, Id = customer.Id, FullName = customer.FullName, Phone = customer.Phone, Order = order });
                }
                return rescustomers;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.Product>> GetProductsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Product>(SqlCommands.GetAllProductsZero);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<CustomerFullStatistic>> GetCustomerStatisticsAsync()
    {

        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<CustomerFullStatistic>(SqlCommands.GetCustomerStatistics);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<OrderFullStatistic>> GetOrderStatisticsAsync()
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                List<OrderFullStatistic> orderFullStatistics = new List<OrderFullStatistic>();
                var orders = await connection.QueryAsync<Domain.Models.Order>(SqlCommands.GetAllOrders);
                foreach (var order in orders)
                {
                    var customer = await connection.QueryFirstOrDefaultAsync<Domain.Models.Customer>(SqlCommands.GetCustomerById, new { Id = order.CustomerId });
                    var product = await connection.QueryFirstOrDefaultAsync<Domain.Models.Product>(SqlCommands.GetProductByOrderId, new { OrderId = order.Id });

                    orderFullStatistics.Add(new OrderFullStatistic() { CreatedAt = order.CreatedAt, CustomerId = order.CustomerId, Status = order.Status, Id = order.Id, OrderDate = order.OrderDate, TotalAmount = order.TotalAmount, Customer = customer, Product = product });
                }
                return orderFullStatistics;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.Order>> GetOrdersByStatusAndDateAsync(string status, DateTime startDate, DateTime endDate)
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                var orders = await connection.QueryAsync<Domain.Models.Order>(SqlCommands.GetOrdersByStatusAndDate, new { Status = status, StartDate = startDate, EndDate = endDate });
                return orders;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    public async Task<Domain.Models.Product?> GetPopularProductAsync()
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Domain.Models.Product>(SqlCommands.GetPopularProduct);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    public async Task<SalesStatistic?> GetSalesStatisticsAsync(int month, int year)
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<SalesStatistic>(SqlCommands.GetSalesStatistics, new { Month = month, Year = year });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.Customer>> GetInactiveCustomersAsync()
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Customer>(SqlCommands.GetInactiveCustomers);
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.Order>> GetOrdersByProductIdAsync(Guid productId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Order>(SqlCommands.GetOrdersByProductId, new { ProductId = productId });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<ProductSummary>> GetProductsSummaryAsync()
    {
        try
        {
            using (var connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<ProductSummary>(SqlCommands.GetProductsSummary);
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }


}
