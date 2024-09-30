using Microsoft.AspNetCore.Mvc;
using infrastructure.Services.Requests;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // 1. Получение клиентов с заказами за определенный период
        [HttpGet("customers/orders")]
        public async Task<IActionResult> GetCustomersWithOrders([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var customers = await _requestService.GetCustomersByDateAsync(startDate, endDate);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // 2. Получение продуктов с нулевым количеством на складе
        [HttpGet("products/out-of-stock")]
        public async Task<IActionResult> GetProductsOutOfStock()
        {
            var products = await _requestService.GetProductsAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // 3. Получение общего количества заказов и общей суммы по каждому клиенту
        [HttpGet("customers/statistics")]
        public async Task<IActionResult> GetCustomerStatistics()
        {
            var statistics = await _requestService.GetCustomerStatisticsAsync();
            if (statistics == null)
            {
                return NotFound();
            }
            return Ok(statistics);
        }

        // 4. Получение всех заказов с информацией о клиентах и товарах
        [HttpGet("orders/details")]
        public async Task<IActionResult> GetOrderStatistics()
        {
            var orderStatistics = await _requestService.GetOrderStatisticsAsync();
            if (orderStatistics == null)
            {
                return NotFound();
            }
            return Ok(orderStatistics);
        }

        // 5. Получение заказов с фильтрацией по статусу и дате заказа
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrdersByStatusAndDate([FromQuery] string status, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var orders = await _requestService.GetOrdersByStatusAndDateAsync(status, startDate, endDate);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // 6. Получение самого популярного продукта по количеству продаж
        [HttpGet("products/popular")]
        public async Task<IActionResult> GetPopularProduct()
        {
            var popularProduct = await _requestService.GetPopularProductAsync();
            if (popularProduct == null)
            {
                return NotFound();
            }
            return Ok(popularProduct);
        }

        // 7. Получение статистики по продажам за месяц
        [HttpGet("orders/sales-statistics")]
        public async Task<IActionResult> GetSalesStatistics([FromQuery] int month, [FromQuery] int year)
        {
            var statistics = await _requestService.GetSalesStatisticsAsync(month, year);
            if (statistics == null)
            {
                return NotFound();
            }
            return Ok(statistics);
        }

        // 8. Получение клиентов, которые не делали заказы в течение последнего года
        [HttpGet("customers/inactive")]
        public async Task<IActionResult> GetInactiveCustomers()
        {
            var inactiveCustomers = await _requestService.GetInactiveCustomersAsync();
            if (inactiveCustomers == null)
            {
                return NotFound();
            }
            return Ok(inactiveCustomers);
        }

        // 9. Получение всех заказов для конкретного продукта
        [HttpGet("products/{productId}/orders")]
        public async Task<IActionResult> GetOrdersByProductId(Guid productId)
        {
            var orders = await _requestService.GetOrdersByProductIdAsync(productId);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // 10. Получение информации о заказах с общей суммой по каждому продукту
        [HttpGet("orders/products-summary")]
        public async Task<IActionResult> GetProductsSummary()
        {
            var productsSummary = await _requestService.GetProductsSummaryAsync();
            if (productsSummary == null)
            {
                return NotFound();
            }
            return Ok(productsSummary);
        }
    }
}
