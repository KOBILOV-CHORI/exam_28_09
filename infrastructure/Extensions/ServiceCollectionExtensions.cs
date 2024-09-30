using infrastructure.Services.Customer;
using infrastructure.Services.Order;
using infrastructure.Services.OrderItem;
using infrastructure.Services.Product;
using infrastructure.Services.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRequestService, RequestService>();

        return services;
    }
}
