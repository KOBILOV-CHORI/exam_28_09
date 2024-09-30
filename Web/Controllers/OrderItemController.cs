using Domain.Models;
using infrastructure.Services.OrderItem;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("OrderItem")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    [HttpPost("OrderItem")]
    public async Task<bool> AddOrderItem(OrderItem orderItem)
    {
        var result = await _orderItemService.AddOrderItemAsync(orderItem);
        return result;
    }
    [HttpPut("OrderItem")]
    public async Task<bool> UpdateOrderItem(OrderItem orderItem)
    {
        var result = await _orderItemService.UpdateOrderItemAsync(orderItem);
        return result;
    }
    [HttpDelete("OrderItem")]
    public async Task<bool> DeleteOrderItem(Guid id)
    {
        var result = await _orderItemService.DeleteOrderItemAsync(id);
        return result;
    }
    [HttpGet("OrderItem")]
    public async Task<OrderItem?> GetOrderItemById(Guid id)
    {
        var result = await _orderItemService.GetOrderItemByIdAsync(id);
        return result;
    }
    [HttpGet("GetOrderItems")]
    public async Task<IEnumerable<OrderItem>> GetOrderItems()
    {
        var result = await _orderItemService.GetOrderItemsAsync();
        return result;
    }
}
