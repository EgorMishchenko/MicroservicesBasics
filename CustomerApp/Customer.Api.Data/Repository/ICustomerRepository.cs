using Customer.Api.Data.Models;

namespace Customer.Api.Data.Repository
{
  public interface ICustomerRepository : IRepository<CustomerTable>
  {
    Task<CustomerTable> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);
  }
}
