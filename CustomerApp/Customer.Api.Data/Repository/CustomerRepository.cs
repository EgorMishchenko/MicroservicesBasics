using Customer.Api.Data.Contexts;
using Customer.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Data.Repository
{
  public class CustomerRepository : Repository<CustomerTable>, ICustomerRepository
  {
    public CustomerRepository(CustomerContext customerContext) : base(customerContext)
    {
    }
    public async Task<CustomerTable> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
      return await CustomerContext.Customer.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
  }
}
