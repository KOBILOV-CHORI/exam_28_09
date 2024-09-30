namespace infrastructure.Services.Customer;

public interface ICustomerService
{
    Task<IEnumerable<Domain.Models.Customer>> GetCustomersAsync();
    Task<bool> DeleteCustomerAsync(Guid id);
    Task<bool> UpdateCustomerAsync(Domain.Models.Customer customer);
    Task<bool> AddCustomerAsync(Domain.Models.Customer customer);
    Task<Domain.Models.Customer?> GetCustomerByIdAsync(Guid id);
}
