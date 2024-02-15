using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Api.Data
{
  public interface ICustomerRepository
  {
    Task<Customer> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);
  }
}
