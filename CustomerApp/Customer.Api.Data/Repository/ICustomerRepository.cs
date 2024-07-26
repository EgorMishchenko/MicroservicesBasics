using Customer.Api.Data.Models;

namespace Customer.Api.Data.Repository
{
  public interface ICustomerRepository
  {
    IEnumerable<CustomerTable> GetAllCustomers();
    Task<CustomerTable> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<CustomerTable>> GetCustomersByEmailAsync(string email, CancellationToken cancellationToken);
    Task<CustomerTable> AddCustomerAsync(CustomerTable customerTable);
    Task<CustomerTable> UpdateCustomerAsync(CustomerTable entity);
  }
}
