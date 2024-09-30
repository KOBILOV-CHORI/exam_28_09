namespace infrastructure.Services.Product;

public interface IProductService
{
    Task<IEnumerable<Domain.Models.Product>> GetProductsAsync();
    Task<bool> DeleteProductAsync(Guid id);
    Task<bool> UpdateProductAsync(Domain.Models.Product product);
    Task<bool> AddProductAsync(Domain.Models.Product product);
    Task<Domain.Models.Product?> GetProductByIdAsync(Guid id);
}
