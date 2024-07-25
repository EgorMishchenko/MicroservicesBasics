using Customer.Api.Data.Models;

namespace Customer.Api.Data.Repository
{
  public interface ICustomerRepository
  {
    Task<CustomerTable> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<CustomerTable>> GetCustomersByEmailAsync(string email, CancellationToken cancellationToken);
    Task<CustomerTable> UpdateCustomerAsync(CustomerTable entity);

  }
}
