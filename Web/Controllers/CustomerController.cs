using Domain.Models;
using infrastructure.Services.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("customer")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpPost("customer")]
    public async Task<bool> AddCustomer(Customer customer)
    {
        var result = await _customerService.AddCustomerAsync(customer);
        return result;
    }
    [HttpPut("customer")]
    public async Task<bool> UpdateCustomer(Customer customer)
    {
        var result = await _customerService.UpdateCustomerAsync(customer);
        return result;
    }
    [HttpDelete("customer")]
    public async Task<bool> DeleteCustomer(Guid id)
    {
        var result = await _customerService.DeleteCustomerAsync(id);
        return result;
    }
    [HttpGet("customer")]
    public async Task<Customer?> GetCustomerById(Guid id)
    {
        var result = await _customerService.GetCustomerByIdAsync(id);
        return result;
    }
    [HttpGet("GetCustomers")]
    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        var result = await _customerService.GetCustomersAsync();
        return result;
    }
}
