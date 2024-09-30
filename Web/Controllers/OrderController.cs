using Domain.Models;
using infrastructure.Services.Order;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("Order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost("Order")]
    public async Task<bool> AddOrder(Order order)
    {
        var result = await _orderService.AddOrderAsync(order);
        return result;
    }
    [HttpPut("Order")]
    public async Task<bool> UpdateOrder(Order order)
    {
        var result = await _orderService.UpdateOrderAsync(order);
        return result;
    }
    [HttpDelete("Order")]
    public async Task<bool> DeleteOrder(Guid id)
    {
        var result = await _orderService.DeleteOrderAsync(id);
        return result;
    }
    [HttpGet("Order")]
    public async Task<Order?> GetOrderById(Guid id)
    {
        var result = await _orderService.GetOrderByIdAsync(id);
        return result;
    }
    [HttpGet("GetOrders")]
    public async Task<IEnumerable<Order>> GetOrders()
    {
        var result = await _orderService.GetOrdersAsync();
        return result;
    }
}
