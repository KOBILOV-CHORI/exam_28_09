using Domain.Models;
using infrastructure.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("Product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPost("Product")]
    public async Task<bool> AddProduct(Product product)
    {
        var result = await _productService.AddProductAsync(product);
        return result;
    }
    [HttpPut("Product")]
    public async Task<bool> UpdateProduct(Product product)
    {
        var result = await _productService.UpdateProductAsync(product);
        return result;
    }
    [HttpDelete("Product")]
    public async Task<bool> DeleteProduct(Guid id)
    {
        var result = await _productService.DeleteProductAsync(id);
        return result;
    }
    [HttpGet("Product")]
    public async Task<Product?> GetProductById(Guid id)
    {
        var result = await _productService.GetProductByIdAsync(id);
        return result;
    }
    [HttpGet("GetProducts")]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        var result = await _productService.GetProductsAsync();
        return result;
    }
}
